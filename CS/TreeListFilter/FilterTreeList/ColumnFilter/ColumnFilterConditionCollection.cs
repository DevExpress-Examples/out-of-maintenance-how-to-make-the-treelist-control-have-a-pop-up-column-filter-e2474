using System.Collections;
using System.IO;
using DevExpress.Utils.Serializing;
using DevExpress.XtraTreeList.Columns;

namespace FilterTreeListControl
{
	public class ColumnFilterConditionCollection : CollectionBase
	{
		private FilterTreeList ownerTreeList;
		
		public ColumnFilterConditionCollection(FilterTreeList treeList)
		{
			OwnerTreeList = treeList;
		}
		public ColumnFilterConditionCollection(FilterTreeList treeList, int capacity)
			: base(capacity)
		{
			OwnerTreeList = treeList;
		}

		public void Assign(ColumnFilterConditionCollection source)
		{
			Clear();
			foreach ( ColumnFilterCondition condition in source )
			{
				ColumnFilterCondition newCondition = new ColumnFilterCondition();
				newCondition.Assign(condition);
				Add(newCondition);
			}
		}

		public int Add(ColumnFilterCondition item)
		{
			item.Collection = this;
			item.FilterConditionPropertyChanged += new FilterConditionPropertyChangedEventHandler(OnItemPropertyChanged);
			return List.Add(item);
		}

		public int IndexOf(ColumnFilterCondition item)
		{
			return List.IndexOf(item);
		}

		public bool Contains(ColumnFilterCondition item)
		{
			return List.Contains(item);
		}

		public bool ContainsColumn(TreeListColumn col)
		{
			for ( int i = 0; i < Count; i++ )
				if ( this[i].Column == col )
					return true;

			return false;
		}

		public override string ToString()
		{
			string filterText = "";
			foreach ( ColumnFilterCondition condition in this )
			{
				string andString = condition != Last ? " AND " : "";
				filterText += condition + andString;
			}

			return filterText;
		}

		protected virtual void SerializeCore(XtraSerializer serializer, object path)
		{
			FilterSerializationHelper filterSerializationHelper = new FilterSerializationHelper(this);
			Stream stream = path as Stream;

			if ( stream != null )
				serializer.SerializeObject(filterSerializationHelper, stream, this.GetType().Name);
			else
				serializer.SerializeObject(filterSerializationHelper, path.ToString(), this.GetType().Name);
		}

		public virtual void SaveToXml(string xmlFile)
		{
			SerializeCore(new XmlXtraSerializer(), xmlFile);
		}
		public virtual void SaveToRegistry(string path)
		{
			SerializeCore(new RegistryXtraSerializer(), path);
		}
		public virtual void SaveToStream(Stream stream)
		{
			SerializeCore(new XmlXtraSerializer(), stream);
		}

		protected virtual void DeserializeCore(XtraSerializer serializer, object path)
		{
			FilterSerializationHelper filterSerializationHelper = new FilterSerializationHelper(this);
			Stream stream = path as Stream;

			if ( stream != null )
				serializer.DeserializeObject(filterSerializationHelper, stream, this.GetType().Name);
			else
				serializer.DeserializeObject(filterSerializationHelper, path.ToString(), this.GetType().Name);
		}

		public virtual void RestoreFromXml(string xmlFile)
		{
			DeserializeCore(new XmlXtraSerializer(), xmlFile);
		}
		public virtual void RestoreFromRegistry(string path)
		{
			DeserializeCore(new RegistryXtraSerializer(), path);
		}
		public virtual void RestoreFromStream(Stream stream)
		{
			DeserializeCore(new XmlXtraSerializer(), stream);
		}

		protected void OnItemPropertyChanged(object sender, FilterConditionPropertyChangedEventArgs e)
		{
			if ( ToString() != "" )
			{
				OwnerTreeList.FilterNodes();
				OwnerTreeList.SetFilterPanelVisibility(true);
			}
		}

		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete(index, value);
			
			if ( ToString() != "" )
			{
				OwnerTreeList.FilterNodes();
				OwnerTreeList.SetFilterPanelVisibility(true);
			}
		}

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete(index, value);
			
			OwnerTreeList.FilterNodes();
			OwnerTreeList.SetFilterPanelVisibility(ToString() != "");
		}

		protected override void OnClearComplete()
		{
			base.OnClearComplete();

			OwnerTreeList.FilterNodes();
			OwnerTreeList.SetFilterPanelVisibility(ToString() != "");
		}

		public ColumnFilterCondition this[int index]
		{
			get { return List[index] as ColumnFilterCondition; }
			set { List[index] = value; }
		}

		public ColumnFilterCondition Last
		{
			get { return List[Count - 1] as ColumnFilterCondition; }
		}

		public FilterTreeList OwnerTreeList
		{
			get { return ownerTreeList; }
			set { ownerTreeList = value; }
		}
	}
}
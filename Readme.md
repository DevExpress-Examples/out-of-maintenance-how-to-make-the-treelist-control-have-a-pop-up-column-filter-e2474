<!-- default file list -->
*Files to look at*:

* [ColumnFilterCondition.cs](./CS/TreeListFilter/FilterTreeList/ColumnFilter/ColumnFilterCondition.cs) (VB: [ColumnFilterConditionCollection.vb](./VB/TreeListFilter/FilterTreeList/ColumnFilter/ColumnFilterConditionCollection.vb))
* [ColumnFilterConditionCollection.cs](./CS/TreeListFilter/FilterTreeList/ColumnFilter/ColumnFilterConditionCollection.cs) (VB: [ColumnFilterConditionCollection.vb](./VB/TreeListFilter/FilterTreeList/ColumnFilter/ColumnFilterConditionCollection.vb))
* [ColumnFilterEngine.cs](./CS/TreeListFilter/FilterTreeList/ColumnFilter/ColumnFilterEngine.cs) (VB: [ColumnFilterEngine.vb](./VB/TreeListFilter/FilterTreeList/ColumnFilter/ColumnFilterEngine.vb))
* [ColumnFilterItem.cs](./CS/TreeListFilter/FilterTreeList/ColumnFilter/ColumnFilterItem.cs) (VB: [ColumnFilterItem.vb](./VB/TreeListFilter/FilterTreeList/ColumnFilter/ColumnFilterItem.vb))
* [FilterItemsComparer.cs](./CS/TreeListFilter/FilterTreeList/ColumnFilter/FilterItemsComparer.cs) (VB: [FilterItemsComparer.vb](./VB/TreeListFilter/FilterTreeList/ColumnFilter/FilterItemsComparer.vb))
* [Operation.cs](./CS/TreeListFilter/FilterTreeList/ColumnFilter/Operation.cs) (VB: [Operation.vb](./VB/TreeListFilter/FilterTreeList/ColumnFilter/Operation.vb))
* [PropertyChangedEventArgs.cs](./CS/TreeListFilter/FilterTreeList/ColumnFilter/PropertyChangedEventArgs.cs) (VB: [PropertyChangedEventArgs.vb](./VB/TreeListFilter/FilterTreeList/ColumnFilter/PropertyChangedEventArgs.vb))
* [FilterTreeList.cs](./CS/TreeListFilter/FilterTreeList/FilterTreeList.cs) (VB: [FilterTreeListViewInfo.vb](./VB/TreeListFilter/FilterTreeList/FilterTreeListViewInfo.vb))
* [FilterTreeListViewInfo.cs](./CS/TreeListFilter/FilterTreeList/FilterTreeListViewInfo.cs) (VB: [FilterTreeListViewInfo.vb](./VB/TreeListFilter/FilterTreeList/FilterTreeListViewInfo.vb))
* [CustomFilterForm.cs](./CS/TreeListFilter/FilterTreeList/Forms/CustomFilterForm.cs) (VB: [CustomFilterForm.vb](./VB/TreeListFilter/FilterTreeList/Forms/CustomFilterForm.vb))
* [PopupForm.cs](./CS/TreeListFilter/FilterTreeList/Forms/PopupForm.cs) (VB: [PopupForm.vb](./VB/TreeListFilter/FilterTreeList/Forms/PopupForm.vb))
* [SerializationHelper.cs](./CS/TreeListFilter/FilterTreeList/SerializationHelper.cs) (VB: [SerializationHelper.vb](./VB/TreeListFilter/FilterTreeList/SerializationHelper.vb))
* [XtraForm1.cs](./CS/TreeListFilter/XtraForm1.cs) (VB: [XtraForm1.vb](./VB/TreeListFilter/XtraForm1.vb))
<!-- default file list end -->
# How to make the TreeList control have a pop up column filter


<p>Starting with version 11.2, this functionality is supported out of-the-box when the TreeList.OptionsBehavior.EnableFiltering option is active. </p><p>This sample shows how a pop up column filter can be added to the TreeList control. Here is a descendant of the TreeList class with filtering capabilities that looks similar to the GridView's pop up column filters. The collection of column filter conditions can be saved and restored with the layout via TreeList's SaveLayout and RestoreLayout methods. Also column filters can be saved and restored separately from the rest of the layout.</p>

<br/>



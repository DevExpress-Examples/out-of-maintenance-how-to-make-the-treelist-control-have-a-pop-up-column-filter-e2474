# How to make the TreeList control have a pop up column filter


<p>Starting with version 11.2, this functionality is supported out of-the-box when the TreeList.OptionsBehavior.EnableFiltering option is active. </p><p>This sample shows how a pop up column filter can be added to the TreeList control. Here is a descendant of the TreeList class with filtering capabilities that looks similar to the GridView's pop up column filters. The collection of column filter conditions can be saved and restored with the layout via TreeList's SaveLayout and RestoreLayout methods. Also column filters can be saved and restored separately from the rest of the layout.</p>

<br/>



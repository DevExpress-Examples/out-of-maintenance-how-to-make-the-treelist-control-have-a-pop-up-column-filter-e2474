<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128637918/11.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2474)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to make the TreeList control have a pop up column filter


<p>Starting with version 11.2, this functionality is supported out of-the-box when the TreeList.OptionsBehavior.EnableFiltering option is active. </p><p>This sample shows how a pop up column filter can be added to the TreeList control. Here is a descendant of the TreeList class with filtering capabilities that looks similar to the GridView's pop up column filters. The collection of column filter conditions can be saved and restored with the layout via TreeList's SaveLayout and RestoreLayout methods. Also column filters can be saved and restored separately from the rest of the layout.</p>

<br/>



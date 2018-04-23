# How to add the search capability to the detail grid


<p>This example demonstrates how to add the search capability to the detail grid.<br>Our detail grid with DataControlDetailDescriptor doesn't support search in the detail grid. To provide this capability in this sample, it's necessary to subscribe to the <a href="https://documentation.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.MasterRowExpanded.event">MasterRowExpanded</a> event. After that, in the <a href="https://documentation.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.MasterRowExpanded.event">MasterRowExpanded</a> event handler, set the detail TableView's <a href="https://documentation.devexpress.com/WPF/DevExpress.Xpf.Grid.DataViewBase.ShowSearchPanelMode.property">ShowSearchPanelMode</a> property to <strong>Never </strong>and bind the detail grid's <a href="https://documentation.devexpress.com/WPF/DevExpress.Xpf.Grid.DataViewBase.SearchString.property">SearchString</a> to the master grid's <a href="https://documentation.devexpress.com/WPF/DevExpress.Xpf.Grid.DataViewBase.SearchString.property">SearchString</a>.</p>

<br/>



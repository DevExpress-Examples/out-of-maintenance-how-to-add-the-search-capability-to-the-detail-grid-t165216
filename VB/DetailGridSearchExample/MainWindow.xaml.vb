Imports DevExpress.Data.Filtering
Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Grid
Imports System.Linq
Imports System.Windows
Imports System.Windows.Data
Imports System.Collections.Generic
Imports System

Namespace DetailGridSearchExample

	Public Class DetailGridSearchingBehavior
		Inherits Behavior(Of GridControl)

		Protected Overrides Sub OnAttached()
			MyBase.OnAttached()

			AddHandler Me.AssociatedObject.Loaded, AddressOf AssociatedObject_Loaded
			AddHandler Me.AssociatedObject.Unloaded, AddressOf AssociatedObject_Unloaded
		End Sub

		Private Sub AssociatedObject_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			AddHandler Me.AssociatedObject.MasterRowExpanded, AddressOf MasterRowExpanded
			Me.AssociatedObject.View.SearchPanelAllowFilter = False
		End Sub

		Private Sub MasterRowExpanded(ByVal sender As Object, ByVal e As RowEventArgs)
			Dim detailView = GetDetailView(e.RowHandle)
			If detailView Is Nothing Then
				Return
			End If
			detailView.ShowSearchPanelMode = ShowSearchPanelMode.Never
			BindingOperations.SetBinding(detailView, DataViewBase.SearchStringProperty, New Binding("SearchString") With {.Source = Me.AssociatedObject.View})
		End Sub
		Private Function GetDetailView(ByVal rowHandle As Integer) As TableView
			Dim detail = TryCast(Me.AssociatedObject.GetDetail(rowHandle), GridControl)
			Return If(detail Is Nothing, Nothing, TryCast(detail.View, TableView))
		End Function

		Private Sub AssociatedObject_Unloaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			RemoveHandler Me.AssociatedObject.MasterRowExpanded, AddressOf MasterRowExpanded
		End Sub
		Protected Overrides Sub OnDetaching()
			RemoveHandler Me.AssociatedObject.Loaded, AddressOf AssociatedObject_Loaded
			RemoveHandler Me.AssociatedObject.Unloaded, AddressOf AssociatedObject_Unloaded
			MyBase.OnDetaching()
		End Sub
	End Class
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

	End Class
End Namespace
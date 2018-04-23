using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DetailGridSearchExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class DetailGridSearchingBehavior : Behavior<GridControl>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
            this.AssociatedObject.Unloaded += AssociatedObject_Unloaded;
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.MasterRowExpanded += this.MasterRowExpanded;
            this.AssociatedObject.View.SearchPanelAllowFilter = false;
        }

        private void MasterRowExpanded(object sender, RowEventArgs e)
        {
            var detailView = this.GetDetailView(e.RowHandle);
            if ((detailView == null))
            {
                return;
            }

            detailView.ShowSearchPanelMode = ShowSearchPanelMode.Never;
            BindingOperations.SetBinding(detailView, DataViewBase.SearchStringProperty, new Binding("SearchString") { Source = AssociatedObject.View });
        }

        public TableView GetDetailView(int rowHandle)
        {
            var detail = this.AssociatedObject.GetDetail(rowHandle) as GridControl;
            return detail != null ? (TableView)detail.View : null;
        }

        private void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.MasterRowExpanded -= this.MasterRowExpanded;
        }
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            this.AssociatedObject.Unloaded -= AssociatedObject_Unloaded;
            base.OnDetaching();
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}

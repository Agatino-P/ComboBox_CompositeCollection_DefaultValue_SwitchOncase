using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

namespace CompositeCollectionApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public class PlaceHolder
        {
            public string DisplayName => "Cosa sei tu?";
        }
        public List<ClassCognome> Cognomi = new List<ClassCognome>() { new ClassCognome("cognome1"), new ClassCognome("cognome2") };
        public List<ClassNome> Nomi = new List<ClassNome>() { new ClassNome("nome1"), new ClassNome("nome2") };



        public object SelectedObj
        {
            get { return (object)GetValue(SelectedObjProperty); }
            set { SetValue(SelectedObjProperty, value); }
        }
        public static readonly DependencyProperty SelectedObjProperty =
            DependencyProperty.Register("SelectedObj", typeof(object), typeof(MainWindow), new PropertyMetadata(null,OnSelectedObjChange));

        private static void OnSelectedObjChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MainWindow mw)
                    { 
                mw.onSelectedObjChange(e.OldValue, e.NewValue);
            }
        }
        private void onSelectedObjChange( object oldValue, object newValue)
        {
            switch (newValue)
            {
                case ClassCognome cCog:
                txt.Text = $"Sei il cognome: {cCog.Cognome}";

                    break;
                case ClassNome cNom:
                    txt.Text = $"Sei il nome: {cNom.Nome}";
                    break;
                default:
                    txt.Text = "Io non ti conosco";
                    break;
            }

        }

        public MainWindow()
        {
            InitializeComponent();
            CompositeCollection cc = new CompositeCollection();
            cc.Add(new PlaceHolder());
            cc.Add(new CollectionContainer() { Collection = Cognomi });
            cc.Add(new CollectionContainer() { Collection = Nomi });
            cb.ItemsSource = cc;
            cb.SelectedIndex = 0;
            cb.DisplayMemberPath = "DisplayName";
        }
    }
}

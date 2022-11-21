using System;
using System.Collections.ObjectModel;

namespace ListViewTest.ViewModels
{
    public class TestLevel3
    {
        public String NameLvl { get; set; }
        public object Data { get; set; }
    }

    public class TestLevel2
    {
        public string NameLVL2 { get; set; } = "";
        public ObservableCollection<TestLevel3> Collection2 { get; set; } = new();
    }

    public class TestLevel1
    {
        public string ObjectName { get; set; } = "LVL1";
        public ObservableCollection<TestLevel2> Collection1 { get; set; } = new();
    }
}
using OpenLabSDK.config;
using OpenLabSDK.error;
using OpenLabSDK.events;
using OpenLabSDK.instruments;
using OpenLabSDK.plugin;
using OpenLabSDK.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace OpenLabStdLib.math
{
    public class LBDecrement : LogicBlock
    {
        public class Info : LogicBlockInfo
        {
            public string UID => "";

            public string Title => "Decrement";

            public int[] version => [1, 0, 0];

            public string vendorUID => "";

            public string url => "";

            public string description => "Decrement by one value of port IN";

            public string instrumentsMenuCategoryTitle => "Math";
        }

        LogicBlockPort inputPortA,inputPortB,outputPort;

        public LBDecrement(IErrorManager _errorManager, IPluginsManager _pluginsManager, IEventsManager _eventsManager, IWindowsManager _windowsManager, InstrumentDefinition instrumentDefinition) : base(_errorManager, _pluginsManager, _eventsManager, _windowsManager, instrumentDefinition)
        {   
            logicBlockInfo = new Info();

            Type type = typeof(float);

            inputPortA = new LogicBlockPort("IN", type, LogicBlockPort.DataDirection.Input);
            inputPortA.settings.horizontalPosition = OpenLabSDK.logicblocks.LogicBlockPortDefaultSettings.Position.Left;
            inputPortA.settings.onDataChangeOperation = LogicBlockPort.OnDataChangeOperations.ExecuteLogicBlockRunMethod;
            addPort(inputPortA);

            inputPortA.settings.dataValueViewerVisibilityChangeByUser = true;
            inputPortA.settings.dataValueEditable = true;

            outputPort = new LogicBlockPort("OUT", type, LogicBlockPort.DataDirection.Output);
            outputPort.settings.horizontalPosition = OpenLabSDK.logicblocks.LogicBlockPortDefaultSettings.Position.Right;
            outputPort.settings.onDataChangeOperation = LogicBlockPort.OnDataChangeOperations.PutDataViaConnection;  
            addPort(outputPort);

            settings.toStartOperation = LogicBlock.ToStartOperations.ExecuteRunMethod;
        }

        private void InputPortOnDataChange(object source, LogicBlockPortDataChangeEventArgs e)
        {
            run();      
        }


        public override void run()
        {
            if (inputPortA.getData(false) != null && inputPortB.getData(false) != null)
            {
                outputPort.setData(inputPortA.getData(false) - 1, false, false);

            }
        }

        public override void stop()
        {
        }
    }
}

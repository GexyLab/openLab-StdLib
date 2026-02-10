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

namespace OpenLabStdLib.physics.constants
{
    public class LBConElementaryCharge : LogicBlock
    {
        LogicBlockPort outputPort;
        public LBConElementaryCharge(IErrorManager _errorManager, IPluginsManager _pluginsManager, IEventsManager _eventsManager, IWindowsManager _windowsManager, InstrumentDefinition instrumentDefinition) : base(_errorManager, _pluginsManager, _eventsManager, _windowsManager, instrumentDefinition)
        {
            logicBlockInfo = new Info();

            outputPort = new LogicBlockPort("OUT",null, LogicBlockPort.DataDirection.Output);
            outputPort.settings.showDataValueViewer = false;
            outputPort.settings.dataValueViewerVisibilityChangeByUser = true;
            outputPort.settings.dataValueEditable = false;

            addPort(outputPort);

            outputPort.setData(1.6021766208e-19, false, false);


        }

        public override void run()
        {
        }

        public override void stop()
        {
        }

        public class Info : LogicBlockInfo
        {
            public string UID => "";

            public string Title => "Elementary charge(C)";

            public int[] version => [1, 0, 0];

            public string vendorUID => "";

            public string url => "";

            public string description => "Elementary charge(C) Constant";

            public string instrumentsMenuCategoryTitle => "Constants";
        }
    }
}

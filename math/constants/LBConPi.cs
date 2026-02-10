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

namespace OpenLabStdLib.math.constants
{
    public class LBConPi : LogicBlock
    {
        LogicBlockPort outputPort;
        public LBConPi(IErrorManager _errorManager, IPluginsManager _pluginsManager, IEventsManager _eventsManager, IWindowsManager _windowsManager, InstrumentDefinition instrumentDefinition) : base(_errorManager, _pluginsManager, _eventsManager, _windowsManager, instrumentDefinition)
        {
            logicBlockInfo = new Info();

            outputPort = new LogicBlockPort("OUT",null, LogicBlockPort.DataDirection.Output);
            outputPort.settings.showDataValueViewer = false;
            outputPort.settings.dataValueViewerVisibilityChangeByUser = true;
            outputPort.settings.dataValueEditable = false;

            addPort(outputPort);

            outputPort.setData(Math.PI, false, false);

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

            public string Title => "Pi";

            public int[] version => [1, 0, 0];

            public string vendorUID => "";

            public string url => "";

            public string description => "Pi constant";

            public string instrumentsMenuCategoryTitle => "Constants";
        }
    }
}

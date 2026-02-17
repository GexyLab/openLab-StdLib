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
    public class LBRandomNumberRange : LogicBlock
    {
        LogicBlockPort outputPort,rangeStartPort, rangeEndPort, generatePort;
        Random rnd = new Random();
        public LBRandomNumberRange(IErrorManager _errorManager, IPluginsManager _pluginsManager, IEventsManager _eventsManager, IWindowsManager _windowsManager, InstrumentDefinition instrumentDefinition) : base(_errorManager, _pluginsManager, _eventsManager, _windowsManager, instrumentDefinition)
        {
            logicBlockInfo = new Info();

            outputPort = new LogicBlockPort("OUT",null, LogicBlockPort.DataDirection.Output);
            outputPort.settings.showDataValueViewer = true;
            outputPort.settings.dataValueViewerVisibilityChangeByUser = true;
            outputPort.settings.dataValueEditable = false;

            addPort(outputPort);

            rangeStartPort = new LogicBlockPort("Start", null, LogicBlockPort.DataDirection.Input);
            rangeStartPort.settings.showDataValueViewer = true;
            rangeStartPort.settings.dataValueViewerVisibilityChangeByUser = true;
            rangeStartPort.settings.dataValueEditable = false;

            addPort(rangeStartPort);

            rangeEndPort = new LogicBlockPort("End", null, LogicBlockPort.DataDirection.Input);
            rangeEndPort.settings.showDataValueViewer = true;
            rangeEndPort.settings.dataValueViewerVisibilityChangeByUser = true;
            rangeEndPort.settings.dataValueEditable = false;

            addPort(rangeEndPort);

            generatePort = new LogicBlockPort("generate", null, LogicBlockPort.DataDirection.Input);
            generatePort.settings.showDataValueViewer = false;
            generatePort.settings.dataValueViewerVisibilityChangeByUser = true;
            generatePort.settings.dataValueEditable = false;

            generatePort.onDataChangeEventAddHandler((object source, LogicBlockPortDataChangeEventArgs e) =>
            {
                run();
            });



        }

        public override void run()
        {
            outputPort.setData(rnd.Next(rangeStartPort.getData(false), rangeEndPort.getData(false)), false, false);
        }

        public override void stop()
        {
        }

        public class Info : LogicBlockInfo
        {
            public string UID => "";

            public string Title => "Random number in range";

            public int[] version => [1, 0, 0];

            public string vendorUID => "";

            public string url => "";

            public string description => "Generate rundom number between specified range";

            public string instrumentsMenuCategoryTitle => "Math";
        }
    }
}

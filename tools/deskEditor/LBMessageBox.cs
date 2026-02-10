using OpenLabSDK.config;
using OpenLabSDK.error;
using OpenLabSDK.events;
using OpenLabSDK.instruments;
using OpenLabSDK.plugin;
using OpenLabSDK.ui;
using System;
using System.Windows;

namespace OpenLabStdLib.tools.deskEditor
{
    public class LBMessageBox : LogicBlock
    {
        LogicBlockPort msgPort, captionPort;
        public LBMessageBox(IErrorManager _errorManager, IPluginsManager _pluginsManager, IEventsManager _eventsManager, IWindowsManager _windowsManager, InstrumentDefinition instrumentDefinition) : base(_errorManager, _pluginsManager, _eventsManager, _windowsManager, instrumentDefinition)
        {

            settings.toStartOperation = ToStartOperations.None;
            settings.toStopOperation = ToStopOperations.None;

            logicBlockInfo = new Info();

            msgPort = new LogicBlockPort("Message", typeof(string),LogicBlockPort.DataDirection.Input);
            msgPort.settings.onDataChangeOperation = LogicBlockPort.OnDataChangeOperations.ExecuteLogicBlockRunMethod;
            msgPort.settings.dataValueEditable = false;
            addPort(msgPort);

            captionPort = new LogicBlockPort("Caption", typeof(string),LogicBlockPort.DataDirection.Input);
            captionPort.settings.onDataChangeOperation = LogicBlockPort.OnDataChangeOperations.None;
            captionPort.settings.dataValueViewerVisibilityChangeByUser = true;
            captionPort.settings.dataValueEditable = true;
            addPort(captionPort);
        }

        public override void run()
        {
            string caption = "Message";
            if (captionPort.getData(false) != null)
            {
                caption = captionPort.getData(false).ToString();
            }

            if (msgPort.getData(false) != null)
            {
                MessageBox.Show(msgPort.getData(false).ToString(),caption);
            }
            else
            {
                MessageBox.Show("NULL",caption);
            }
        }

        public override void stop()
        {
        }

        public class Info : LogicBlockInfo
        {
            public string UID => "";

            public string Title => "MessageBox";

            public int[] version => [1, 0, 0];

            public string vendorUID => "";

            public string url => "";

            public string description => "";

            public string instrumentsMenuCategoryTitle => "Tools";
        }
    }
}

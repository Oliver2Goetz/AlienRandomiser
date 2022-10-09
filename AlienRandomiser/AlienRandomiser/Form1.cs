using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlienRandomiser
{
    public partial class Form1 : Form
    {
        private Random _random = new Random();
        private List<MissionMapping> _missionMaps = new List<MissionMapping>();
        private Label[] _missionEndLabels = null;

        public Form1()
        {
            InitializeComponent();
            _missionEndLabels = new Label[] { order_1, order_2, order_3, order_4, order_5, order_6, order_7, order_8, order_9, order_10, order_11, order_12, order_13, order_14, order_15, order_16, order_17, order_18 };
        }

        private void randomiseOrder_Click(object sender, EventArgs e)
        {
            _missionMaps.Clear();
            List<int> usedMissions = new List<int>();
            for (int i = 1; i < 19; i++)
            {
                int randomNextMission = i;
                while (randomNextMission == i || usedMissions.Contains(randomNextMission))
                    randomNextMission = _random.Next(19) + 1;
                usedMissions.Add(randomNextMission);

                MissionMapping missionMapping = new MissionMapping();
                missionMapping.mission_start = i;
                missionMapping.mission_end = randomNextMission;
                _missionMaps.Add(missionMapping);
            }

            ReSyncUI();
        }

        private void launchGame_Click(object sender, EventArgs e)
        {

        }

        private void ReSyncUI()
        {
            foreach (MissionMapping mapping in _missionMaps)
                _missionEndLabels[mapping.mission_start - 1].Text = mapping.mission_end.ToString();
        }

        private class MissionMapping
        {
            public int mission_start = 1;
            public int mission_end = 1;

            public string GetAsString()
            {
                return "Mission " + mission_start + " to " + mission_end;
            }
        }
    }
}

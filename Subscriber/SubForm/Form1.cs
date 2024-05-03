namespace SubForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<Part> Parts = new List<Part>();

        public List<Event> Events = new List<Event>();

        private void timer1_Tick(object sender, EventArgs e)
        {
            EventType currentType = EventType.NOT_SET;

            if (Events.Count > 0)
            {
                currentType = Events[0].localType;
            }

            foreach (Part part in Parts)
            {
                if (part.Subs.Contains(currentType))
                {
                    label1.Text = part.HandleNewEvent(Events[0]).ToString();
                }
            }

            if (currentType != EventType.NOT_SET)
            {
                Events.RemoveAt(0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                label2.Text = "Steht";
            }
            else
            {
                timer1.Start();
                label2.Text = "Läuft";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int leo = comboBox1.SelectedIndex;

            Event newEV = new Event((EventType)leo);

            Events.Add(newEV);
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Parts.Add(new GameObject(Character.charType));
            Parts.Add(new UserInterface());
        }
    }
}
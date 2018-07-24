using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Threading;

namespace TraderGridTestDemo
{
    public class ViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.InitializeDataTable();
            this.SetupTimer();
        }
        #endregion

        #region Properties

        private int toggleInsertRemove = 10;
        private int insertRemoveModulus = 5;
        private int insertRemoveCount = 1;
        private int icount = 0;
        private bool shouldInsert = false;
        private int ti = 0;
        private long startTickCount;
        private int addedColumns = 0;
        private Random rand;
        private int initialRowCount = 200;
        private DispatcherTimer timer;
        private TimeSpan timerInterval = new TimeSpan(0, 0, 0, 0, 30);
        private int timerCount = 0;
        private int stopAtTimerCount = -1;
        private int numberOfChangesEachTimer = 100;
        private bool insertAndRemoveRecords = true;
        private bool insertAndRemoveColumns = false;

        private DataTable table;
        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        /// <value>The table.</value>
        public DataTable Table
        {
            get { return table; }
            set { table = value; }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Setups the timer.
        /// </summary>
        private void SetupTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 2, 1);
            timer.Start();
        }

        /// <summary>
        /// Initializes the data table.
        /// </summary>
        private void InitializeDataTable()
        {
            table = new DataTable("RandomData");
            table.Columns.Add("Product", typeof(string));
            for (int n = 1; n <= 30; n++)
            {
                table.Columns.Add(n.ToString(), typeof(System.Double));
            }

            rand = new Random(0);

            for (int i = 0; i < initialRowCount; i++)
            {
                double next = rand.Next(100);
                object[] values = new object[table.Columns.Count];
                values[0] = "P" + i.ToString("00000");
                for (int n = 1; n < table.Columns.Count; n++)
                    values[n] = next + n;
                table.Rows.Add(values);
            }
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (timerCount == 0)
            {
                timer.Interval = timerInterval;
                startTickCount = Environment.TickCount;
            }

            timerCount++;
            if (stopAtTimerCount > 0)
            {
                if (timerCount == stopAtTimerCount)
                {
                    timer.Tick -= new EventHandler(timer_Tick);
                    timer.Stop();
                    return;
                }
                else if (timerCount > stopAtTimerCount)
                    return;
            }

            for (int i = 0; i < numberOfChangesEachTimer; i++)
            {
                int recNum = rand.Next(table.Rows.Count - 1);
                int col = rand.Next(table.Columns.Count - 1) + 1;
                DataRow drow = table.Rows[recNum];
                if (drow.RowState != DataRowState.Deleted && !(drow[col] is DBNull))
                {
                    double value = (int)(Convert.ToDouble(drow[col]) * (rand.Next(50) / 100.0f + 0.8));
                    drow[col] = value;
                }
            }

            if (insertAndRemoveColumns)
            {
                if (timerCount % 100 == 29)
                {
                    table.Columns.Add("A" + (addedColumns++).ToString(), typeof(double));
                }

                if (timerCount % 100 == 59)
                {
                    table.Columns.Remove(table.Columns[5]);
                }
            }

            // Insert or remove a row
            if (insertRemoveCount == 0 || !insertAndRemoveRecords)
                return;

            if (toggleInsertRemove > 0 && (timerCount % insertRemoveModulus) == 0)
            {
                icount = ++icount % (toggleInsertRemove * 2);
                shouldInsert = icount < toggleInsertRemove;

                if (shouldInsert)
                {
                    for (int ri = 0; ri < insertRemoveCount; ri++)
                    {
                        int recNum = rand.Next(Math.Min(30, table.Rows.Count));

                        double next = rand.Next(100);

                        object[] values = new object[table.Columns.Count];
                        values[0] = "H" + ti.ToString("00000");
                        for (int n = 1; n < table.Columns.Count; n++)
                            values[n] = next + n;

                        DataRow drow = table.NewRow();
                        drow.ItemArray = values;
                        table.Rows.InsertAt(drow, recNum);

                        ti++;
                    }
                }
                else
                {
                    for (int ri = 0; ri < insertRemoveCount; ri++)
                    {
                        int recNum = 5; //rand.Next(m_set.Count - 1);
                        int rowNum = recNum + 1;

                        // Underlying data structure (this could be a datatable or whatever structure
                        // you use behind a virtual grid).

                        if (table.Rows.Count > 10)
                            table.Rows.RemoveAt(recNum);
                    }
                }
            }
        }

        #endregion
    }
}

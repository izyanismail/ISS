using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class Homepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string time = "10:15";
        string[] result2 = time.Split(':');
        Session["F"] = int.Parse(result2[0]) - 1;
        int G = int.Parse(result2[1]);


        //Response.Write(G);
        //Response.End();

        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

        int j = 8;
        int inc = 10;
        DateTime startTime = DateTime.Today.AddHours(j).AddMinutes(50);//new DateTime(2013,9,6,18,40,0,DateTimeKind.Local);//DateTime.Today.AddHours(10).AddMinutes(50);
        DateTime endTime = DateTime.Today.AddHours(18).AddMinutes(35);//DateTime.Now;
        //Response.Write(startTime);
        //Response.End();

        List<DateTime> timeList = new List<DateTime>();
        //while (startTime < DateTime.Now.AddMinutes(inc))
        while (startTime < endTime.AddMinutes(inc))
        {
            timeList.Add(startTime);
            startTime = startTime.AddMinutes(inc);
            dr = dt.NewRow();
            dr["RowNumber"] = startTime;
            dt.Rows.Add(dr);
        }

        GridView1.DataSource = dt;
        GridView1.RowStyle.Height = 50;
        GridView1.DataBind();
        //for (int i = G; i <= 60; i += 10)
        //{


        //    dt.Rows.Add(i); 
        //   // Label1.Text = i.ToString();
        //}

       
        //int a = CalculateTimerInterval(time);
        //Label1.Text = a.ToString();
    }

    int CalculateTimerInterval(int minute)
    {
        if (minute <= 0)
            minute = 60;
        DateTime now = DateTime.Now;

        DateTime future = now.AddMinutes((minute - (now.Minute % minute))).AddSeconds(now.Second * -1).AddMilliseconds(now.Millisecond * -1);

        TimeSpan interval = future - now;

        return (int)interval.TotalMilliseconds;
    }

    //static System.Windows.Forms.Timer t;
    //const int CHECK_INTERVAL = 20;


    //static void Main()
    //{
    //    t = new System.Windows.Forms.Timer();
    //    t.Interval = CalculateTimerInterval(CHECK_INTERVAL);
    //    t.Tick += new EventHandler(t_Tick);
    //    t.Start();
    //}

    //static void t_Tick(object sender, EventArgs e)
    //{
    //    t.Interval = CalculateTimerInterval(CHECK_INTERVAL);
    //}
}
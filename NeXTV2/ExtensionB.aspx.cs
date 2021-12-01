using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using System.Data;
using Newtonsoft.Json;

public partial class ExtensionB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime time = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector8.Hour, TimeSelector8.Minute, TimeSelector8.Second, TimeSelector8.AmPm));

        Session["Time"] = time.ToString("HH:mm");

        //listDate();
        // getISS();
        //Response.Write(Session["Time"]);
        //Response.End();

        DateTime date = Calendar1.SelectedDate;

        string dateTime = Calendar1.SelectedDate.ToString("ddd MMM dd yyyy") + " " + time.ToString("hh:mm tt");

        // String A = "Wed, 01 Dec 2021 03:17:10 GMT";
        DateTime convertedDate = DateTime.Parse(dateTime);
        //long s = 1436029902;

        //DateTime result = FromUnixTime(s);

        Double re = ConvertToUnixTimestamp(convertedDate);

        long a = 1638328630;
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
        string json = (new WebClient()).DownloadString("https://api.wheretheiss.at/v1/satellites/25544/positions?timestamps=" + re + "&units=miles");
        GridView1.DataSource = JsonConvert.DeserializeObject<DataTable>(json);
        GridView1.DataBind();


    }

    public void getISS()
    {
        DataTable dt = new DataTable();
        int numRows = 0;

        numRows = dt.Rows.Count;

        for (int index2 = 1; index2 <= numRows; index2++)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string json = (new WebClient()).DownloadString("https://api.wheretheiss.at/v1/satellites/25544/positions?timestamps=" + dt.Rows[index2]["RowNumber"] + "&units=miles");
            GridView1.DataSource = JsonConvert.DeserializeObject<DataTable>(json);
            GridView1.DataBind();


        }
    }


    public void listDate()
    {
        string time = Session["Time"].ToString();
        string[] result2 = time.Split(':');
        int F = int.Parse(result2[0]) - 1;
        int G = int.Parse(result2[1]);


        //Response.Write(G);
        //Response.End();
        DateTime date = Calendar1.SelectedDate;

        DataTable dt = new DataTable();
        int numRows = 0;
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        //numRows = dt.Rows.Count;


        //int j = 8;
        int inc = 10;
        DateTime startTime = date.AddHours(F).AddMinutes(G);//new DateTime(2013,9,6,18,40,0,DateTimeKind.Local);//DateTime.Today.AddHours(10).AddMinutes(50);
        DateTime endTime = startTime.AddHours(2);//DateTime.Now;
        //Response.Write(startTime);
        //Response.End();

        List<DateTime> timeList = new List<DateTime>();
        //while (startTime < DateTime.Now.AddMinutes(inc))
        while (startTime < endTime.AddMinutes(inc))
        {
            timeList.Add(startTime);
            startTime = startTime.AddMinutes(inc);
            Double re = ConvertToUnixTimestamp(startTime);

            dr = dt.NewRow();
            dr["RowNumber"] = re;
            dt.Rows.Add(dr);
        }
        numRows = dt.Rows.Count;

        DataTable dataIss = new DataTable();
        int Rows = 0;
        DataRow dr2 = null;
        dataIss.Columns.Add(new DataColumn("ISS1", typeof(string)));

        //var table = Tables[0]; //get first table from Dataset
        foreach (DataRow row in dt.Rows)
        {
            foreach (var item in row.ItemArray)
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                string json = (new WebClient()).DownloadString("https://api.wheretheiss.at/v1/satellites/25544/positions?timestamps=" + item + "&units=miles");
                //GridView1.DataSource = JsonConvert.DeserializeObject<DataTable>(json);
                //GridView1.DataBind();

                Session["data"] = JsonConvert.DeserializeObject<DataTable>(json);
                //GridView1.DataBind();
                //Session["data"] =
                //dataIss.Fill(JsonConvert.DeserializeObject<DataTable>(json));
                dr2 = dataIss.NewRow();
                dr2["ISS1"] = JsonConvert.DeserializeObject<DataTable>(json);
                dataIss.Rows.Add(dr2);
            }
        }

        GridView1.DataSource = dataIss;
        GridView1.DataBind();

        //Response.Write(numRows);
        //Response.End();

        //DataTable dataIss = new DataTable();
        //int Rows = 0;
        //DataRow dr2 = null;
        //dataIss.Columns.Add(new DataColumn("ISS1", typeof(string)));


        //for (int index2 = 1; index2 <= 12; index2++)
        //{
        //    ServicePointManager.Expect100Continue = true;
        //    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
        //    string json = (new WebClient()).DownloadString("https://api.wheretheiss.at/v1/satellites/25544/positions?timestamps=" + dt.Rows[index2]["RowNumber"] + "&units=miles");
        //    GridView1.DataSource = JsonConvert.DeserializeObject<DataTable>(json);
        //    GridView1.DataBind();

        //    Session["data"] = JsonConvert.DeserializeObject<DataTable>(json);
        //    //GridView1.DataBind();
        //    //Session["data"] = 
        //    //dataIss.Fill(JsonConvert.DeserializeObject<DataTable>(json));
        //    dr2 = dataIss.NewRow();
        //    dr2["ISS1"] = JsonConvert.DeserializeObject<DataTable>(json);
        //    dataIss.Rows.Add(Session["data"]);


        //}

        //GridView1.DataSource = dataIss;
        //GridView1.RowStyle.Height = 50;
        //GridView1.DataBind();
    }

    public static double ConvertToUnixTimestamp(DateTime date)
    {
        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        TimeSpan diff = date.ToUniversalTime() - origin;
        return Math.Floor(diff.TotalSeconds);
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Calendar1.Visible)
        {
            Calendar1.Visible = false;
        }
        else
        {
            Calendar1.Visible = true;
        }
        Calendar1.Attributes.Add("style", "position:absolute");
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        TextBox2.Text = Calendar1.SelectedDate.ToString("ddd MMM dd yyyy");
        //DateFrom.Text = Calendar1.SelectedDate.ToString("dd/MM/yyy");

        Calendar1.Visible = false;
    }
}
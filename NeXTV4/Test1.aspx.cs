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
using Newtonsoft.Json.Linq;

public partial class Test1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //findLocation();
            //TextBox2.Text = DateTime.Now.ToString("ddd MMM dd yyyy");
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            //string json = (new WebClient()).DownloadString("https://api.wheretheiss.at/v1/satellites/25544/positions?timestamps=1436029892,1436029902&units=miles");
            //GridView1.DataSource = JsonConvert.DeserializeObject<DataTable>(json);
            //GridView1.DataBind();
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime time = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector8.Hour, TimeSelector8.Minute, TimeSelector8.Second, TimeSelector8.AmPm));

        Session["Time"] = time.ToString("HH:mm");
        
        listDate();
       // getISS();
        findLocation();
       

        DateTime date = Calendar1.SelectedDate;

        string dateTime = Calendar1.SelectedDate.ToString("ddd MMM dd yyyy") + " " + time.ToString("hh:mm tt");

        // String A = "Wed, 01 Dec 2021 03:17:10 GMT";
        DateTime convertedDate = DateTime.Parse(dateTime);
        //long s = 1436029902;

        //DateTime result = FromUnixTime(s);
        //Response.Write(dateTime);
        //Response.End();
        Double re = ConvertToUnixTimestamp(convertedDate);

        long a = 1638328630;
        //ServicePointManager.Expect100Continue = true;
        //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
        //string json = (new WebClient()).DownloadString("https://api.wheretheiss.at/v1/coordinates/51.30823209243,-140.58411254882");
        //GridView1.DataSource = JsonConvert.DeserializeObject<DataTable>(json);
        //GridView1.DataBind();


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
        //string time = Session["Time"].ToString();
        //string[] result2 = time.Split(':');
        //int F = int.Parse(result2[0]) - 1;
        //int G = int.Parse(result2[1]);
       
        DateTime timeSelected = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector8.Hour, TimeSelector8.Minute, TimeSelector8.Second, TimeSelector8.AmPm));
       
        //System.DateTime dTime = timeSelected;
        //System.TimeSpan tSpan = new System.TimeSpan(0, 1, 0, 0);
        
        //System.DateTime date4 = dTime.Subtract(tSpan);

        string time = timeSelected.ToString("hh:mm");
        string[] result2 = time.Split(':');
        int F = int.Parse(result2[0]) - 1;
        int G = int.Parse(result2[1]);

       
        string dateTime = Calendar1.SelectedDate.ToString("ddd MMM dd yyyy") + " " + timeSelected.ToString("hh:mm tt");
        DateTime date2 = DateTime.Parse(dateTime);

        System.DateTime dTime = date2;
        System.TimeSpan tSpan = new System.TimeSpan(0, 1, 0, 0);

        System.DateTime date4 = dTime.Subtract(tSpan);
        //Response.Write(date4);
        //Response.End();

        DataTable dt = new DataTable();
        int numRows = 0;
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        //numRows = dt.Rows.Count;

        DataTable dtDate = new DataTable();
        DataRow dr3 = null;
        dtDate.Columns.Add(new DataColumn("Date", typeof(string)));


        DataTable dataIss = new DataTable();
        int Rows = 0;
        DataRow dr2 = null;
        //dataIss.Columns.Add(new DataColumn("Date", typeof(string)));
        dataIss.Columns.Add(new DataColumn("Name", typeof(string)));
        dataIss.Columns.Add(new DataColumn("Id", typeof(string)));
        dataIss.Columns.Add(new DataColumn("Latitude", typeof(string)));
        dataIss.Columns.Add(new DataColumn("Longitude", typeof(string)));

        //int j = 8;
        int inc = 10;
        DateTime startTime = date4.AddHours(0).AddMinutes(0);//new DateTime(2013,9,6,18,40,0,DateTimeKind.Local);//DateTime.Today.AddHours(10).AddMinutes(50);
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

            dr3 = dtDate.NewRow();
            dr3["Date"] = startTime;
            dtDate.Rows.Add(dr3);

            dr = dt.NewRow();
            dr["RowNumber"] = re;
            dt.Rows.Add(dr);
        }
        numRows = dt.Rows.Count;

        
        

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

                string dataJason = json;
                //Response.Write(dataJason);
                //Response.End(); 

               char[] charsToTrim2 = { '{', '}', '[' ,']'};
               String dataJasonTrim = dataJason.Trim(charsToTrim2);
               //Response.Write(dataJasonTrim);
               //Response.End();

               // string time = Session["Time"].ToString();
               string[] result3 = dataJasonTrim.Split(',');
               char[] TrimD1 = { ':', '"', 'n', 'a','m','e'};
               string d1 = result3[0].Trim(TrimD1); ;

               char[] TrimD2 = { ':', '"', 'i', 'd' };
               string d2 = result3[1].Trim(TrimD2);

               char[] TrimD3 = { ':', '"', 'l', 'a', 't', 'i', 'u', 'd', 'e' };
               string d3 = result3[2].Trim(TrimD3);

               char[] TrimD4 = { ':', '"', 'l', 'o', 't', 'i', 'u', 'd', 'e','n','g'};
               string d4 = result3[3].Trim(TrimD4);

                
                dr2 = dataIss.NewRow();
                dr2["name"] = d1;
                dr2["id"] = d2;
                dr2["latitude"] = d3;
                dr2["longitude"] = d4;
                dataIss.Rows.Add(dr2);
            }
        }

        Session["DATAISS"]=dataIss;

        GridView1.DataSource = dataIss;
        GridView1.DataBind();

        GridView2.DataSource = dtDate;
        GridView2.DataBind();

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

    public void findLocation()
    {
        DataTable accData = Session["DATAISS"] as DataTable;
        int noRows = accData.Rows.Count;

        DataTable loc = new DataTable();
        DataRow drow = null;
        loc.Columns.Add(new DataColumn("Timezone_id", typeof(string)));
        loc.Columns.Add(new DataColumn("Country_code", typeof(string)));
        loc.Columns.Add(new DataColumn("Map_url", typeof(string)));
       

        //GridView1.DataSource = accData;
        //GridView1.RowStyle.Height = 50;
        //GridView1.DataBind();

        for (int index = 0; index < noRows; index++)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string json = (new WebClient()).DownloadString("https://api.wheretheiss.at/v1/coordinates/" + accData.Rows[index]["latitude"].ToString() + "," + accData.Rows[index]["longitude"].ToString());
            //string json = (new WebClient()).DownloadString("https://api.wheretheiss.at/v1/coordinates/37.795517,-122.393693");

            string dataJason = json;
            //Response.Write(json);
            //Response.End();

            char[] charsToTrim2 = { '{', '}', '[', ']' };
            String dataJasonTrim = dataJason.Trim(charsToTrim2);
            //Response.Write(dataJasonTrim);
            //Response.End();

            // string time = Session["Time"].ToString();
            string[] result3 = dataJasonTrim.Split(',');
            char[] TrimD1 = { ':', '"', 't', 'i', 'm', 'e','z','o','n','e','_','i','d','"','"','/' };
            string d1 = result3[2].Trim(TrimD1); ;

            char[] TrimD2 = { ':', '"', 'c', 'o','u','n','t','r','y','_','c','o','d','e' };
            string d2 = result3[4].Trim(TrimD2);

            char[] TrimD3 = { ':', '"', 'm', 'a', 'p', '_', 'u', 'r', 'l' };
            string d3 = result3[5].Trim(TrimD3);

            //char[] TrimD4 = { ':', '"', 'l', 'o', 't', 'i', 'u', 'd', 'e', 'n', 'g' };
            //string d4 = result3[3].Trim(TrimD4);


            drow = loc.NewRow();
            drow["Timezone_id"] = d1;
            drow["Country_code"] = d2;
            drow["Map_url"] = d3;
           
            loc.Rows.Add(drow);
        }
        GridView3.DataSource = loc;
        GridView3.DataBind();
        
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudyingplanApp.Enums;
namespace StudyingplanApp
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 30; i++)
            {
                ChaptersDropBox.Items.Add(i.ToString());
            }
        }
        protected void ImageButtonCalendar_Click(object sender, ImageClickEventArgs e)
        {
            Calendar.Visible = true;
        }

        /// <summary>
        /// Gets the selected date on the Calendar control and writes in TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dt = Calendar.SelectedDate;
            TextBoxDate.Text = dt.ToString("dd/MM/yyyy");
            if (IsdatesValid(TextBoxDate.Text))
            {
                TextBoxDate.Text = dt.ToString("dd/MM/yyyy");
                Calendar.Visible = false;
            }



        }
        private bool IsdatesValid(string dt)
        {
            bool isValid = true;
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");

            if (Convert.ToDateTime(dt) < DateTime.Now)
            {
                isValid = false;
                TextBoxDate.CssClass = "error";
                sb.Append(String.Format("<li>{0}</li>", "Please enter a valid date"));
            }
            else
            {
                TextBoxDate.CssClass = " ";
            }

            sb.Append("</ul>");
            ltrlErrorMsg.Text = sb.ToString();
            return isValid;
        }
        private bool isControlValid(List<int> arrofWorkDays)
        {
            bool isValid = true;
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");
            if ( string.IsNullOrEmpty(noOfsessionstxt.Text) )

            {
                isValid = false;
                noOfsessionstxt.CssClass = "error";
                sb.Append(String.Format("<li>{0}</li>", "number of sessions is required"));

            }
            else
            {
                noOfsessionstxt.CssClass = " ";
            }
            if(ChaptersDropBox.SelectedValue == null )
            {
                isValid = false;
                ChaptersDropBox.CssClass= "error";
                sb.Append(String.Format("<li>{0}</li>", "Please choose a starting chapter"));
            }
            else
            {
                ChaptersDropBox.CssClass = " ";
            }
            if(string.IsNullOrEmpty(TextBoxDate.Text) || Calendar.SelectedDate <= DateTime.Now)
            {
                isValid = false;
                TextBoxDate.CssClass= "error";
                sb.Append(String.Format("<li>{0}</li>", "Please enter a valid date"));
            }
            else
            {
                TextBoxDate.CssClass= " ";
            }
            if (arrofWorkDays.Count < 2)
            {
                isValid = false;

                DaysList.CssClass= "error";
                sb.Append(String.Format("<li>{0}</li>", "Please choosea at least 2 workdays"));
            }
            else
            {
                DaysList.CssClass = " ";

            }
            sb.Append("</ul>");
            ltrlErrorMsg.Text = sb.ToString();
            return isValid;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            WebService1 webService = new WebService1();
            List<int> arrofWorkDays = new List<int>();

            foreach (ListItem item in DaysList.Items)
            {
                if (item.Selected)
                {
                    WeekEnum Weekday = (WeekEnum)Enum.Parse(typeof(WeekEnum), item.Value);
                    arrofWorkDays.Add(Convert.ToInt32(Weekday));
                }
            }
            if (isControlValid(arrofWorkDays))
            {
                Outputtxt.Text = webService.GetStudyingPlan(TextBoxDate.Text, arrofWorkDays, Convert.ToInt32(noOfsessionstxt.Text), ChaptersDropBox.SelectedValue).ToString();

                EveryChapterDays.Text = webService.GetDaysperChapter(arrofWorkDays, Convert.ToInt32(noOfsessionstxt.Text), ChaptersDropBox.SelectedValue).ToString();

            }

        }
    }
}
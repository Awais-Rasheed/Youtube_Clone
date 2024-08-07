using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Youtube
{
    public partial class Form1 : Form
    {
        private const string apiKey = "AIzaSyD956TgDYNIPgC2qVLx2YUvnBjmcEDE3Uk";
        public Form1()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            string query = search_query.Text;

            var videos = SearchYouTubeVideos(query);

            this.AutoScroll = true;

            DisplayResults(videos);

            comboBox1.Items.Add(query);
        }

        private SearchListResponse SearchYouTubeVideos(string query)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = "Youtube"
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = query;
            searchListRequest.MaxResults = 21;

            return searchListRequest.Execute();
        }

        private void DisplayResults(SearchListResponse videos)
        {
            int panelIndex = 0;
            const int panelsPerRow = 3;

            foreach (var result in videos.Items)
            {
                if (result.Id.Kind == "youtube#video")
                {
                    string videoId = result.Id.VideoId;
                    string title = result.Snippet.Title;
                    string description = result.Snippet.Description;

                    var videoStatistics = GetVideoStatistics(videoId);
                    string videoUrl = $"https://www.youtube.com/watch?v={videoId}";

                    string thumbnailUrl = result.Snippet.Thumbnails.Medium.Url;

                    System.Net.WebRequest request = System.Net.WebRequest.Create(thumbnailUrl);
                    System.Net.WebResponse response = request.GetResponse();
                    System.IO.Stream responseStream = response.GetResponseStream();
                    System.Drawing.Image thumbnailImage = System.Drawing.Image.FromStream(responseStream);

                    double? viewsCount = videoStatistics?.Statistics?.ViewCount;

                    //dataGridView1.Rows.Add(thumbnailImage, videoId, title, description, videoStatistics?.Statistics?.ViewCount, videoUrl);

                    Panel panel = new Panel();
                    panel.Size = new System.Drawing.Size(300, 250);
                    // panel.Location = new System.Drawing.Point(10 + (310 * panelIndex), 100);

                    int row = panelIndex / panelsPerRow;
                    int col = panelIndex % panelsPerRow;
                    panel.Location = new System.Drawing.Point(100 + (310 * col), 100 + (270 * row));

                    PictureBox pic = new PictureBox();
                    pic.Image = thumbnailImage.Clone() as System.Drawing.Image;
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Dock = DockStyle.Fill;

                    panel.Controls.Add(pic);
                    this.Controls.Add(panel);

                    Label titleLabel = new Label();
                    titleLabel.Text = title;
                    Font titleFont = new Font("Arial", 8, FontStyle.Bold);

                    titleLabel.Font = titleFont;
                    titleLabel.Dock = DockStyle.Bottom;
                    panel.Controls.Add(titleLabel);

                    Font desFont = new Font("Arial", 8);

                    Label viewLabel = new Label();
                    viewLabel.Font = desFont;
                    viewLabel.Text = "Views " + viewsCount;
                    viewLabel.Dock = DockStyle.Bottom;
                    viewLabel.ForeColor = Color.Red;


                    Font urlFont = new Font("Arial", 7, FontStyle.Bold);
                    LinkLabel urlLabel = new LinkLabel();
                    urlLabel.Font = urlFont;
                    urlLabel.Text = videoUrl;
                    urlLabel.Dock = DockStyle.Bottom;
                    panel.Controls.Add(urlLabel);
                    panel.Controls.Add(viewLabel);
                    panelIndex++;
                }
            }

        }

        private Video GetVideoStatistics(string videoId)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = "YouTubeSearchApp"
            });

            var videosListRequest = youtubeService.Videos.List("statistics");
            videosListRequest.Id = videoId;

            var response = videosListRequest.Execute();

            return response.Items.Count > 0 ? response.Items[0] : null;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void search_query_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
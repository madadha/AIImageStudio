

 
תוכן עניינים

1. מבוא
2. מהות האפליקציה
3. מטרות הפרויקט
4. טכנולוגיות בשימוש
5. מבנה הפרויקט
6. הסבר על המסכים
7. כלים ואלגוריתמים
8. מדריך משתמש
9. צילומי מסך
10. סיכום

 
מבוא

בפרויקט זה פיתחתי אפליקציית WPF חכמה בשם AI Image Studio.
האפליקציה מאפשרת למשתמש לעבוד עם מודלים של בינה מלאכותית, לשוחח עם מודלים שונים, להשתמש בכלים חיצוניים, וליצור תמונות מטקסט.

הפרויקט נבנה בשפת C# באמצעות WPF, ומשלב שירותי AI כגון Gemini ו-OpenAI.
בנוסף, שולבו באפליקציה כלים חיצוניים כמו כלי תאריך ושעה, כלי חישוב מתמטי, וכן אפשרות ליצירת תמונות באמצעות בינה מלאכותית.

מטרת הפרויקט היא להציג מערכת חכמה המשלבת ממשק משתמש מודרני, שימוש במודלים של AI, ושימוש בכלים שמרחיבים את יכולות המודל.

 
מהות האפליקציה

האפליקציה AI Image Studio היא מערכת חכמה המאפשרת למשתמש לבצע מספר פעולות מרכזיות:

1. לנהל שיחה עם מודל בינה מלאכותית.
2. לבחור בין מודלים שונים כגון Gemini ו-ChatGPT.
3. להשתמש בכלים חיצוניים:
   - DateTimeTool לקבלת תאריך ושעה.
   - CalculatorTool לביצוע חישובים מתמטיים.
4. ליצור תמונות מתוך תיאור טקסטואלי.
5. לשמור תמונה שנוצרה על ידי המערכת.

המערכת פועלת בצורה אינטראקטיבית: המשתמש כותב שאלה או בקשה, המודל מנתח אותה, ואם יש צורך בכלי מסוים, האפליקציה מפעילה את הכלי ומחזירה את התוצאה למודל.

 
מטרות הפרויקט

מטרות הפרויקט הן:

1. בניית אפליקציית WPF עם ממשק משתמש מודרני ונוח.
2. שילוב מודלי בינה מלאכותית באפליקציה.
3. שימוש בשני כלים לפחות לפי דרישות המטלה.
4. מימוש כלי תאריך ושעה.
5. מימוש כלי חישוב מתמטי.
6. הוספת אפשרות ליצירת תמונות באמצעות AI.
7. הצגת תוצאות בצורה ברורה ונוחה למשתמש.
8. בניית פרויקט מסודר לפי תיקיות ושכבות.

 
טכנולוגיות בשימוש

בפרויקט נעשה שימוש בטכנולוגיות הבאות:

1. C#
שפת התכנות המרכזית שבה נכתב הפרויקט.

2. WPF
טכנולוגיה לבניית ממשק משתמש גרפי מתקדם.

3. Gemini API
שירות AI של Google לצורך שיחה עם מודל בינה מלאכותית.

4. OpenAI API
שירות AI לצורך יצירת תמונות ו/או עבודה עם מודל ChatGPT.

5. JSON
שימוש בפורמט JSON לצורך קבלת החלטה מובנית מהמודל לגבי שימוש בכלים.

6. Tools
שימוש בכלים חיצוניים שמופעלים על ידי האפליקציה לפי החלטת המודל.
 
מבנה הפרויקט

הפרויקט בנוי בצורה מסודרת ומחולק לתיקיות:

Models:
מכילה מחלקות מודל כגון ToolDecision ו-ToolExecutionResult.

Services:
מכילה מחלקות שירות המתקשרות עם מודלי AI, לדוגמה GeminiToolService ו-OpenAIImageService.

Tools:
מכילה את הכלים החיצוניים:
DateTimeTool
CalculatorTool

Views:
מכילה את מסכי המערכת:
SelectModelWindow
ChatWindowGemini
ChatWindowOpenAI
ImageGenerationWindow

Styles:
מכילה קבצי עיצוב אחידים למערכת.

Helpers:
מכילה מחלקות עזר וולידציה במידת הצורך.
הסבר על המסכים
1.	המסך הראשי

מסך ראשי - SelectModelWindow

זהו המסך הראשון שנפתח בעת הפעלת האפליקציה.
במסך זה המשתמש יכול לבחור את הפעולה הרצויה:
- מעבר לצ'אט עם Gemini.
- מעבר לצ'אט עם ChatGPT.
- מעבר למסך יצירת תמונות.

המסך מעוצב בצורה מודרנית וברורה, ומאפשר ניווט נוח בין חלקי המערכת.
 

תמונה 2: המסך הראשי של האפליקציה
 
2.	מסך Gemini Chat

מסך Gemini Chat
במסך זה המשתמש יכול לנהל שיחה עם מודל Gemini.
המשתמש כותב הודעה, והמערכת שולחת אותה למודל.
אם המודל מזהה צורך בכלי, כמו חישוב או תאריך, המערכת מפעילה את הכלי המתאים ומחזירה תשובה סופית למשתמש.
המסך כולל:
- אזור הצגת שיחה.
- תיבת כתיבת הודעה.
- כפתור שליחה.
- כפתור ניקוי שיחה.
- כפתור ניקוי זיכרון.
- כפתור חזרה.
 

תמונה 3: מסך צ'אט Gemini

מסך יצירת תמונות

מסך יצירת תמונות - ImageGenerationWindow

במסך זה המשתמש כותב תיאור טקסטואלי של תמונה שהוא רוצה ליצור.
לאחר לחיצה על כפתור יצירה, המערכת שולחת את התיאור למודל יצירת תמונות ומציגה את התמונה שנוצרה על המסך.

המסך כולל:
- תיבת טקסט לכתיבת Prompt.
- אזור תצוגה מקדימה לתמונה.
- כפתור יצירת תמונה.
- כפתור ניקוי.
- כפתור הורדת תמונה.
- כפתור חזרה.
 

	תמונה 4: מסך יצירת תמונות
כלים ואלגוריתמים

בפרויקט נעשה שימוש בשני כלים מרכזיים:

1. DateTimeTool
כלי זה מחזיר את התאריך והשעה הנוכחיים.
כאשר המשתמש שואל שאלות כמו "מה השעה עכשיו?" או "מה התאריך היום?", המודל יכול לבקש שימוש בכלי זה.

2. CalculatorTool
כלי זה מבצע חישובים מתמטיים.
כאשר המשתמש שואל שאלות כמו "כמה זה 5*5?", המודל מבקש שימוש בכלי החישוב, והמערכת מחזירה את התוצאה.

בנוסף, נעשה שימוש במנגנון החלטה מבוסס JSON.
המודל מחזיר החלטה האם להשתמש בכלי, מה שם הכלי, ומה הקלט שיש להעביר אליו.

דוגמה:
UseTool = true
ToolName = calculator
ToolInput = 5*5
 
קוד XAML
דוגמה לקוד XAML

הקוד הבא מציג חלק ממסך יצירת התמונות, הכולל תיבת Prompt, אזור תצוגת תמונה וכפתורים
<Window x:Class="SmartChat.WPF.Views.ImageGenerationHebrewWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="יצירת תמונה"
        Height="780"
        Width="1150"
        MinHeight="720"
        MinWidth="1050"
        WindowStartupLocation="CenterScreen"
        Background="#F1F5F9"
        FlowDirection="RightToLeft">

    <Grid Margin="24">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>

        <!-- Header -->
        <Border Grid.Row="0"
                Background="#0F172A"
                CornerRadius="22"
                Padding="28"
                Margin="0,0,0,18">
            <DockPanel>
                <StackPanel DockPanel.Dock="Right">
                    <TextBlock Text="🎨 יצירת תמונות בבינה מלאכותית"
                               FontSize="32"
                               FontWeight="Bold"
                               Foreground="White"/>

                    <TextBlock Text="צור תמונות מקצועיות מתוך תיאור טקסטואלי"
                               FontSize="16"
                               Foreground="#CBD5E1"
                               Margin="0,8,0,0"/>
                </StackPanel>

                <TextBlock Text="SmartChat WPF AMadadha"
                           DockPanel.Dock="Left"
                           FontSize="16"
                           FontWeight="SemiBold"
                           Foreground="#38BDF8"
                           VerticalAlignment="Center"
                           HorizontalAlignment="Left"/>
            </DockPanel>
        </Border>

        <!-- Main Content -->
        <Grid Grid.Row="1">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="20"/>
                <ColumnDefinition Width="380"/>
            </Grid.ColumnDefinitions>

            <!-- Image Preview Card -->
            <Border Grid.Column="0"
                    Background="White"
                    CornerRadius="26"
                    Padding="18"
                    BorderBrush="#CBD5E1"
                    BorderThickness="1">
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="*"/>
                    </Grid.RowDefinitions>

                    <DockPanel Grid.Row="0" Margin="0,0,0,14">
                        <TextBlock Text="🖼️ תצוגה מקדימה"
                                   FontSize="21"
                                   FontWeight="Bold"
                                   Foreground="#0F172A"
                                   DockPanel.Dock="Right"/>

                        <TextBlock Text="1024 × 1024"
                                   FontSize="13"
                                   Foreground="#64748B"
                                   HorizontalAlignment="Left"
                                   DockPanel.Dock="Left"/>
                    </DockPanel>

                    <Border Grid.Row="1"
                            Background="#E2E8F0"
                            CornerRadius="24"
                            BorderBrush="#94A3B8"
                            BorderThickness="2"
                            Padding="14">
                        <Grid>
                            <Border Background="#F8FAFC"
                                    CornerRadius="18"
                                    BorderBrush="#CBD5E1"
                                    BorderThickness="1"/>

                            <TextBlock x:Name="txtStatus"
                                       Text="התמונה שתיווצר תופיע כאן"
                                       HorizontalAlignment="Center"
                                       VerticalAlignment="Center"
                                       Foreground="#64748B"
                                       FontSize="20"
                                       FontWeight="SemiBold"
                                       TextAlignment="Center"/>

                            <Image x:Name="imgGenerated"
                                   Stretch="Uniform"
                                   Visibility="Collapsed"
                                   ClipToBounds="True"/>
                        </Grid>
                    </Border>
                </Grid>
            </Border>

            <!-- Prompt Card -->
            <Border Grid.Column="2"
                    Background="White"
                    CornerRadius="22"
                    Padding="24"
                    BorderBrush="#CBD5E1"
                    BorderThickness="1">
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="*"/>
                        <RowDefinition Height="Auto"/>
                    </Grid.RowDefinitions>

                    <StackPanel Grid.Row="0">
                        <TextBlock Text="✍️ תיאור התמונה"
                                   FontSize="21"
                                   FontWeight="Bold"
                                   Foreground="#0F172A"/>

                        <TextBlock Text="כתוב תיאור ברור של התמונה שברצונך ליצור"
                                   FontSize="13"
                                   Foreground="#64748B"
                                   Margin="0,6,0,16"/>
                    </StackPanel>

                    <TextBox x:Name="txtPrompt"
                             Grid.Row="1"
                             MinHeight="360"
                             TextWrapping="Wrap"
                             AcceptsReturn="True"
                             VerticalScrollBarVisibility="Auto"
                             Padding="14"
                             FontSize="15"
                             Background="#F8FAFC"
                             Foreground="#0F172A"
                             BorderBrush="#CBD5E1"
                             BorderThickness="1.5"/>

                    <TextBlock Grid.Row="2"
                               Text="דוגמה: לוגו מודרני לחברת ניקיון בשם אלשאם קלין, צבעים כחול ולבן, סגנון מקצועי ויוקרתי"
                               TextWrapping="Wrap"
                               FontSize="12"
                               Foreground="#64748B"
                               Margin="0,14,0,0"/>
                </Grid>
            </Border>
        </Grid>
        <Border Grid.Row="2"
                Background="White"
                CornerRadius="22"
                Padding="16"
                Margin="0,18,0,0"
                BorderBrush="#CBD5E1"
                BorderThickness="1">
            <UniformGrid Columns="4" Rows="1">
                <Button x:Name="btnGenerate"
                        Content="✨ צור תמונה"
                        Height="56"
                        Margin="8"
                        Background="#2563EB"
                        Foreground="White"
                        FontSize="16"
                        FontWeight="Bold"
                        Cursor="Hand"
                        BorderThickness="0"
                        Click="btnGenerate_Click"/>

                <Button x:Name="btnClear"
                        Content="🧹 נקה"
                        Height="56"
                        Margin="8"
                        Background="#64748B"
                        Foreground="White"
                        FontSize="16"
                        FontWeight="Bold"
                        Cursor="Hand"
                        BorderThickness="0"
                        Click="btnClear_Click"/>

                <Button x:Name="btnSave"
                        Content="⬇️ הורד תמונה"
                        Height="56"
                        Margin="8"
                        Background="#10B981"
                        Foreground="White"
                        FontSize="16"
                        FontWeight="Bold"
                        Cursor="Hand"
                        BorderThickness="0"
                        Click="btnSave_Click"/>

                <Button x:Name="btnBack"
                        Content="↩️ חזרה"
                        Height="56"
                        Margin="8"
                        Background="DodgerBlue"
                        Foreground="White"
                        FontSize="16"
                        FontWeight="Bold"
                        Cursor="Hand"
                        BorderThickness="0"
                        Click="btnBack_Click"/>
            </UniformGrid>
        </Border>
    </Grid>
</Window>
קוד C#
הקוד הבא מציג את מחלקת השירות או את הפעלת הכלים במערכת.
המחלקה מקבלת בקשה מהמשתמש, בודקת האם יש צורך בהפעלת כלי, מפעילה את הכלי המתאים ומחזירה תשובה למשתמש.


namespace SmartChat.WPF.Views
{
    public partial class ImageGenerationHebrewWindow : Window
    {
        private readonly OpenAIImageService imageService;
        private string generatedImagePath = string.Empty;

        public ImageGenerationHebrewWindow()
        {
            InitializeComponent();
            imageService = new OpenAIImageService();
        }

        private async void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string prompt = txtPrompt.Text.Trim();

            if (string.IsNullOrWhiteSpace(prompt))
            {
                MessageBox.Show("נא להזין תיאור לתמונה.");
                txtPrompt.Focus();
                return;
            }

            btnGenerate.IsEnabled = false;
            txtPrompt.IsEnabled = false;
            txtStatus.Text = "יוצר תמונה, נא להמתין...";
            txtStatus.Visibility = Visibility.Visible;
            imgGenerated.Visibility = Visibility.Collapsed;

            try
            {
                generatedImagePath = await imageService.GenerateImageAsync(prompt);

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(generatedImagePath);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                imgGenerated.Source = bitmap;
                imgGenerated.Visibility = Visibility.Visible;
                txtStatus.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                txtStatus.Text = "אירעה שגיאה ביצירת התמונה.";
                txtStatus.Visibility = Visibility.Visible;
                MessageBox.Show("שגיאה: " + ex.Message);
            }
            finally
            {
                btnGenerate.IsEnabled = true;
                txtPrompt.IsEnabled = true;
                txtPrompt.Focus();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtPrompt.Clear();
            imgGenerated.Source = null;
            imgGenerated.Visibility = Visibility.Collapsed;
            txtStatus.Text = "התמונה שתיווצר תופיע כאן";
            txtStatus.Visibility = Visibility.Visible;
            generatedImagePath = string.Empty;
            txtPrompt.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(generatedImagePath) || !File.Exists(generatedImagePath))
            {
                MessageBox.Show("אין תמונה לשמירה.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PNG Image|*.png",
                FileName = "SmartChat_Generated_Image.png"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                File.Copy(generatedImagePath, saveFileDialog.FileName, true);
                MessageBox.Show("התמונה נשמרה בהצלחה.");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            SelectModelWindow window = new SelectModelWindow();
            window.Show();
            this.Close();
        }
    }
}


מדריך משתמש

כדי להריץ את הפרויקט יש לבצע את השלבים הבאים:
1. לפתוח את הפרויקט ב-Visual Studio.
2. לוודא שכל חבילות NuGet מותקנות.
3. להגדיר מפתחות API:
   - GEMINI_API_KEY
   - OPENAI_API_KEY
4. להריץ את הפרויקט.
5. במסך הראשי לבחור את הפעולה הרצויה:
   - Gemini Chat
   - ChatGPT Chat
   - Image Generation
6. בצ'אט ניתן לשאול שאלות רגילות או שאלות הדורשות שימוש בכלים.
7. במסך יצירת תמונות ניתן לכתוב תיאור תמונה וליצור תמונה חדשה.

 
צילומי מסך

צילומי מסך

במסמך צורפו מספר צילומי מסך המציגים את חלקי הפרויקט:

1.	מסך ראשי.
 
2.	מסך צ'אט.
 
3.	מסך יצירת תמונות.
 
 


קישור לפרויקט GitHub:
https://github.com/madadha/AIImageStudio.git



 
סיכום

בפרויקט זה פותחה אפליקציה חכמה בשם AI Image Studio.
האפליקציה משלבת ממשק משתמש מתקדם, מודלי בינה מלאכותית, כלים חיצוניים ויצירת תמונות.

הפרויקט עומד בדרישות המטלה מכיוון שהוא כולל:
- פנייה למודל AI.
- שימוש בשני כלים לפחות.
- ממשק משתמש גרפי.
- אפשרות ליצירת תמונות.
- תיעוד וצילומי מסך.

במהלך העבודה למדתי כיצד לשלב מודלי AI בתוך אפליקציית WPF, כיצד לבנות כלי עזר חיצוניים, וכיצד ליצור מערכת חכמה שמסוגלת לבצע פעולות מעבר למענה טקסטואלי רגיל.
 
רפלקציה

במהלך העבודה על הפרויקט למדתי כיצד לשלב בינה מלאכותית בתוך אפליקציית WPF בצורה מעשית ומתקדמת.
הפרויקט עזר לי להבין כיצד עובדים מודלי AI, כיצד ניתן להשתמש בכלים חיצוניים בתוך מערכת חכמה, וכיצד ליצור ממשק משתמש מודרני ונוח.

בנוסף, למדתי לעבוד עם APIs של Gemini ו-OpenAI, לנהל תקשורת עם מודלים, לבצע יצירת תמונות באמצעות AI, ולבנות מערכת מסודרת המחולקת למחלקות ותיקיות.

במהלך הפיתוח התמודדתי עם מספר אתגרים, כגון:
- עבודה עם Streaming
- ניהול זיכרון שיחה
- שימוש בכלים בצורה דינמית
- טיפול בשגיאות API
- שמירת תמונות וטעינתן

למרות האתגרים, הפרויקט תרם לי רבות מבחינה מקצועית וטכנית, ושיפר את הידע שלי בפיתוח אפליקציות WPF ובתחום הבינה המלאכותית.


 
תודה למרצה

ברצוני להודות למרצה Gilad Markman
על הליווי, ההסברים והעזרה במהלך הקורס.

הקורס תרם לי רבות להבנת תחום הבינה המלאכותית, העבודה עם מודלים חכמים, ושילוב AI בתוך אפליקציות אמיתיות.

תודה על ההכוונה, הסבלנות והידע המקצועי שהועבר במהלך הלמידה.

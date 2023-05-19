using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotClient
{
    internal class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [System.Runtime.InteropServices.DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        static async Task Main(string[] args)
        {
            ShowWindow(GetConsoleWindow(), 1);

            var botClient = new TelegramBotClient("6209445245:AAHTaXL9FDut2QlxzisjIFow7gUVsFXoth8");

            using CancellationTokenSource cts = new CancellationTokenSource();

            ReceiverOptions receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
                );


            HttpClient client = new HttpClient();


            Console.WriteLine("Googogogogogog");
            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            cts.Cancel();
        }
        static async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("https://localhost:44356/api/Good");
            var test = await result.Content.ReadAsStringAsync();
            var r2 = await client.GetAsync("https://localhost:44356/api/Category");
            var t2 = await r2.Content.ReadAsStringAsync();
            }
        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
            CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                await HandleCallbackQuery(botClient, update.CallbackQuery);
                return;
            }
            if (update.Message is not { } message)
                return;
            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}");
            ReplyKeyboardMarkup replyKeyboardMarkup = new
            (
                new[]
                {
                    new KeyboardButton[] { "Картинка", "Стикер", "Видео", "Категория" },
                }
            )
            {
                ResizeKeyboard = true
            };

            if (message.Text == "Привет" || message.Text == "Здравствуйте"  || message.Text == "/start" )
            {        
                Random rnd = new Random();
                string[] answers = new string[] { "Здравствуйте, уважаемый(ая)! ", "qq", "Опять людишки пишут.....", "привет всем няшкам ^w^", "Привет!!!" };
                await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: answers[rnd.Next(0, answers.Length)],
                replyMarkup: replyKeyboardMarkup,
                cancellationToken: cancellationToken);
            }    

            if (message.Text == "Картинка")
            {
                Random rnd = new Random();
                string[] answers = new string[] 
                {
                    "https://sun9-72.userapi.com/impg/riltBTFHuo5xXDa-ldKiijgMof2p9a5uCS_azw/76iZFGBWcDU.jpg?size=1026x800&quality=95&sign=fae7dfb33394bfa84a59c9cdd7fb7146&type=album",
                    "https://sun9-71.userapi.com/impg/90EbFec0Uc5rqYIWiZJ_4GLIp33dXEdhepnmUQ/ZM62WEafqNY.jpg?size=1139x1080&quality=96&sign=b69350a886c8dc97e45b8e0c185b4e4c&type=album",
                    "https://sun9-77.userapi.com/impg/I7Se2liq9_oGgEv5IcqMgrzfku7RKogNBXGV0Q/7mkghqH6Vi0.jpg?size=735x550&quality=95&sign=f5d749a0ddc159529a9ba3144b0cd3ff&type=album",
                    "https://sun9-40.userapi.com/impg/gOwrXXnlZttRszVoqr5ELKq3J7kaiS5RRNIbfw/ewQK_wSkBQ8.jpg?size=1149x958&quality=95&sign=a1e637a22b2ae262108d802492cfc2f1&type=album",
                    "https://vnsalesman.files.wordpress.com/2019/03/61.jpg?w=614&h=461",
                    "https://sun9-16.userapi.com/impg/9A30hAjiIA-neNzifdq2uqpjoSb2M6Ser5scWQ/qw-_WBxLZ1s.jpg?size=1330x1472&quality=95&sign=55ef975c11af2c2c87a733e53ad0e341&type=album",
                    "https://sun9-75.userapi.com/impg/GEyo4vRCYvOgkQmIxo76WPHmGFmk81yKkRBYtw/vLYteq4O_cU.jpg?size=1038x973&quality=95&sign=c9762bf6b885fbb22ca1150e0bbbc857&type=album",
                    "https://sun9-4.userapi.com/impg/cFL3cwsnjlifgaopyZ24y18NucjBiDP3InbHgw/CuAGz2WoZIo.jpg?size=1125x833&quality=96&sign=8c093a73429aea9e6d469661db194ba9&type=album",
                    "https://sun9-51.userapi.com/impg/47Ua5q0aGuXptyailwUWq9WuBbocBbWSpU4pRg/wuQNDZSnjlE.jpg?size=604x453&quality=96&sign=e1bba843d83e568e3366d9f5d39cfb88&type=album",
                    "https://r2.mt.ru/r29/photoC056/20495078856-0/jpg/bp.jpeg" };
                await botClient.SendPhotoAsync(
                chatId: chatId,
                photo: answers[rnd.Next(0, answers.Length)],
                caption: "<b>красивая картинка</b>",
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);
            }
            if (message.Text == "Стикер")
            {
                Random rnd = new Random();
                string[] answers = new string[] 
                {
                    "https://cdn.tlgrm.app/stickers/bd6/830/bd683093-2847-4c16-855c-a288f4009328/192/9.webp",
                    "https://tlgrm.ru/_/stickers/bd6/830/bd683093-2847-4c16-855c-a288f4009328/192/27.webp",
                    "https://tlgrm.ru/_/stickers/bd6/830/bd683093-2847-4c16-855c-a288f4009328/192/41.webp",
                    "https://tlgrm.ru/_/stickers/bd6/830/bd683093-2847-4c16-855c-a288f4009328/192/32.webp",
                    "https://cdn.tlgrm.app/stickers/bd6/830/bd683093-2847-4c16-855c-a288f4009328/192/3.webp"
                };
                await botClient.SendStickerAsync(
                chatId: chatId,
                sticker: answers[rnd.Next(0, answers.Length)],
                cancellationToken: cancellationToken);
            }
            if (message.Text == "Видео")
            {
                Random rnd = new Random();
                string[] answers = new string[]
                {
                    "https://clck.ru/34RcwJ",
                    "https://clck.ru/34TNrj",
                    "https://clck.ru/34TNk8",
                    "https://clck.ru/34TNYM"
                };
                await botClient.SendVideoAsync(
                chatId: chatId,
                video: answers[rnd.Next(0, answers.Length)],
                caption: "и в чём он не прав?",
                supportsStreaming: true,
                cancellationToken: cancellationToken);
            }
        }
        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception,
            CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}

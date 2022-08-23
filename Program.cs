using Telegram.Bot;



var bot = new TelegramBotClient("5750458149:AAGtR5rq2UJ7QZmdFcT--Ee9hqx4Y84l4Fc");

var updates = bot.GetUpdatesAsync();


while (true)
{
    if (updates.Result.Length > 0)
    {
        Console.WriteLine("Existen actualizaciones");
        foreach (var up in updates.Result)
        {
            if (up.Message != null)
            {
                Console.WriteLine(up.Message.Text);
                var mensaje = up.Message;
                switch (up.Message.Text)
                {
                    case "E": // Error 
                        bot.SendTextMessageAsync(mensaje.Chat.Id, "<h3>Holaaa</h3>", Telegram.Bot.Types.Enums.ParseMode.Html);
                        break;
                    case "A": // Advertencia
                        bot.SendTextMessageAsync(mensaje.Chat.Id, "<h1>Holaaa</h1>", Telegram.Bot.Types.Enums.ParseMode.Html);
                        break;
                    default:
                        bot.SendTextMessageAsync(mensaje.Chat.Id, "<b>Holaaa</b>", Telegram.Bot.Types.Enums.ParseMode.Html);
                        break;

                }
                // Enviamos un mensaje de respuesta al chat
                bot.SendTextMessageAsync(mensaje.Chat.Id, "Holaaa");

            }
                
        }
        updates = bot.GetUpdatesAsync(updates.Result.Max(u => u.Id)+1);

    }else
    {
        updates = bot.GetUpdatesAsync();
    }
}

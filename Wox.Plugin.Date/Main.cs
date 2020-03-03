using System;
using System.Collections.Generic;

namespace Wox.Plugin.Date
{
    public class Main : IPlugin
    {
        public void Init(PluginInitContext context)
        {
        }

        public List<Result> Query(Query query)
        {
            var results = new List<Result>();

            results.Add(new Result()
            {
                Title = $"{DateTime.Now}",
                SubTitle = $"Data/Hora Atual",
                IcoPath = "Images\\icon.png",
                Action = e =>
                {
                    return false;
                }
            });

            return results;
        }

    }
}

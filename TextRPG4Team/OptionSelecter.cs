using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG4Team
{
     public class OptionSelecter
     {
          private class OptionContainer
          {
               public string optionName = string.Empty;
               public Action optionEvent { get; set; } = delegate { };

               public void Invoke()
               {
                    optionEvent?.Invoke();
               }
          }

          private Dictionary<string, OptionContainer> options;
          private OptionContainer exception;

          private OptionSelecter()
          {
               options = new Dictionary<string, OptionContainer>();
               exception = new OptionContainer();
          }

          public static OptionSelecter Create()
          {
               return new OptionSelecter();
          }

          public void SetExceptionMessage(string msg)
          {
               exception.optionName = msg;
          }
          public void SetExceptionEvent(Action? action)
          {
               exception.optionEvent += action;
          }

          public void AddOption(string text, string key, Action? action = null)
          {
               if (!options.TryGetValue(key, out var result))
               {
                    OptionContainer container = new OptionContainer();

                    container.optionName = text;
                    container.optionEvent += action;

                    options.Add(key, container);
               }
          }

          public void Select(string frontText = "")
          {
               Console.Write(frontText);
               string? input = Console.ReadLine();

               if (options.TryGetValue(input, out var value))
               {
                    value?.Invoke();
               }
               else
               {
                    if (exception.optionName.Length >= 1)
                    {
                         Console.WriteLine(exception?.optionName);
                    }
                    exception?.Invoke();
                    Select(frontText);
               }
          }

          public void Display()
          {
               foreach (var iter in options)
               {
                    Console.WriteLine(iter.Value.optionName);
               }
          }
     }
}

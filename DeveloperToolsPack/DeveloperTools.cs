using System;
using System.Collections.Generic;
using System.Text;
using DeveloperToolsPack.DateTime;
using DeveloperToolsPack.Guid;
using DeveloperToolsPack.Interfaces;
using DeveloperToolsPack.Number;
using DeveloperToolsPack.String;

namespace DeveloperToolsPack
{
    public class DeveloperTools
    {
        private Dictionary<string, ITool> _tools;
        private string _channelId;

        public DeveloperTools(string channelId = "skype")
        {
            AddTool(new ToUpper());
            AddTool(new ToLower());
            AddTool(new NewGuid());
            AddTool(new ConvertTo());
            AddTool(new FromBase64());
            AddTool(new ToBase64());
            AddTool(new FromUnixTime());
            AddTool(new ToUnixTime());
            AddTool(new Password());
            _channelId = channelId;
        }

        private void AddTool(ITool tool)
        {
            if (_tools == null)
            {
                _tools = new Dictionary<string, ITool>();
            }
            if (!_tools.ContainsKey(tool.CommandName.ToLower()))
            {
                _tools.Add(tool.CommandName.ToLower(), tool);
            }
        }

        public string Run(string str)
        {
            if (!System.String.IsNullOrEmpty(str))
            {
                str = str.Trim();
                var indexOfSpace = str.IndexOf(" ", StringComparison.Ordinal);
                string command;
                var commandText = "";
                if (indexOfSpace != -1)
                {
                    command = str.Substring(0, indexOfSpace).ToLower();
                    commandText = str.Substring(indexOfSpace+1, str.Length - indexOfSpace-1);
                }
                else
                {
                    command = str.ToLower();
                }
                var originalCommand = command;
                if (command[0] != '/')
                {
                    command = "/" + command;
                }

                if (_tools.ContainsKey(command))
                {
                    return _tools[command].Run(commandText);
                }
                else
                {
                    if (command == "/help")
                    {
                        var returnString = new StringBuilder();
                        foreach (var tool in _tools)
                        {
                            switch (_channelId)
                            {
                                case "skype": returnString.Append($"**{tool.Value.CommandName.Trim('/')}** - {tool.Value.Description}\n\r"); break;
                                default:
                                    returnString.Append($"{tool.Value.CommandName.ToLower()} - {tool.Value.Description}\n\r");
                                    break;
                            }
                        }
                        return returnString.ToString();
                    }
                    string help;
                    switch (_channelId)
                    {
                        case "skype":
                            help = "help"; break;
                        default:
                            help = "/help";
                            break;
                    }

                    return $"Command \"**{originalCommand}**\" not found. See \"**{help}**\" command.";
                }
            }
            return "Please input a string";
        }
    }
}

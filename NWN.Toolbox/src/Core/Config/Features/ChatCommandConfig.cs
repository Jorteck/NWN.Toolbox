using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Jorteck.Toolbox.Core
{
  [Serializable]
  internal sealed class ChatCommandConfig : IFeatureConfig
  {
    [Description("Enable/disable the chat command system.")]
    public bool Enabled { get; set; } = true;

    [Description("Character prefixes that define if a message is detected as a command.")]
    public List<string> CommandPrefixes { get; set; } = new List<string> { "/" };

    [Description("A list of words/prefixes that are ignored by command processing. E.g. '/' ignores all usages of '//' if the command prefix is /.")]
    public List<string> IgnoreCommands { get; set; } = new List<string> { "/" };
  }
}

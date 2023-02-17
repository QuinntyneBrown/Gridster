// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.Messages;

public class Message
{
    public string MessageType { get; set; } = nameof(Message);
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
}



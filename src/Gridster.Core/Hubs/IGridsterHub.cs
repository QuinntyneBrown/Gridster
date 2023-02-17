// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.Hubs;

public interface IGridsterHub
{
    Task Message(string message);

}



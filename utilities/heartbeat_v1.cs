// ==========================================
// Space Engineers Script
// Author: AsterakisGR
// Purpose: Displays a heartbeat message in the programmable block
// Blocks Required: Programmable Block
// Grid: Both
// Version: 1.0
// Status: Untested
// Last Updated: 2025-XX-XX
// ==========================================

public Program()
{
    Runtime.UpdateFrequency = UpdateFrequency.Update100;
}

public void Main(string argument)
{
    Echo("Heartbeat OK");
    Echo("Time: " + DateTime.Now.ToString("HH:mm:ss"));
}

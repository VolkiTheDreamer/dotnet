private void ScrollToBottomOfMessages()
{
    rtbMessages.SelectionStart = rtbMessages.Text.Length;
    rtbMessages.ScrollToCaret();
}

namespace ItemSystem.Management
{
    public class ItemTransfer
    {
        private ItemsManager sender;
        private ItemsManager receiver;

        public ItemTransfer(ItemsManager sender, ItemsManager receiver)
        {
            this.sender = sender;
            this.receiver = receiver;
        }

        public bool SendItem(ItemData itemData)
        {
            if (!sender.SendItem(itemData)) return false;

            if (!receiver.ReceiveItem(itemData))
            {
                sender.ReceiveItem(itemData);

                return false;
            }

            return true;
        }
    }
}

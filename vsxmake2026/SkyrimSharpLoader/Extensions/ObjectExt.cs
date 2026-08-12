namespace SkyrimSharpLoader.Extensions
{
    public static class ObjectExt
    {
        public static string NonNullString(this object msg)
        {
            if (msg == null)
                return "null";
            else
            {
                var str = msg.ToString();

                if (str == null)
                    return "null";
                else return str;
            }
        }
    }
}

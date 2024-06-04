namespace Business.Utilities.Constants;

public static class Messages
{
    public static string CarrierAdded = "Kargo firması eklendi";
    public static string CarriersListed(int count)
    {
        return count + " Adet kargo firması listelendi";
    }
    public static string CarrierListed(int id)
    {
        return id + " Id'li kargo firması";
    }
    public static string CarrierUpdated(int id)
    {
        return id + " Id'li kargo firması güncellendi";
    }
    public static string CarrierDeleted(int id)
    {
        return id + " Id'li kargo firması silindi";
    }

    public static string CarrierConfAdded = "Kargo konfigrasyonu eklendi";
    public static string CarrierConfsListed(int count)
    {
        return count + " Adet kargo konfigürasyonu listelendi";
    }
    public static string CarrierConfListed(int id)
    {
        return id + " Id'li kargo konfigürasyonu";
    }
    public static string CarrierConfUpdated(int id)
    {
        return id + " Id'li kargo konfigürasyonu güncellendi";
    }
    public static string CarrierConfDeleted(int id)
    {
        return id + " Id'li kargo konfigürasyonu silindi";
    }

    public static string OrderAdded = "Sipariş oluşturuldu.";
    public static string OrdersListed(int count)
    {
        return count + " Adet sipariş listelendi";
    }
    public static string OrderListed(int id)
    {
        return id + " Id'li sipariş";
    }
    public static string OrderUpdated(int id)
    {
        return id + " Id'li sipariş güncellendi";
    }
    public static string OrderDeleted(int id)
    {
        return id + " Id'li sipariş silindi";
    }
}
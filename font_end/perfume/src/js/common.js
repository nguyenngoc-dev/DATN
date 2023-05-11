export function formatMoney (money)  {
    try {
        money = new Intl.NumberFormat("vi-VN", { style: "currency", currency: "VND" }).format(
            money
        );
        return money;
    } catch (error) {
        return "";
    }
}
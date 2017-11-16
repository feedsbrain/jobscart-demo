import { CheckoutDetail } from './checkoutdetail';

export class Checkout {
    orderDetails: Array<CheckoutDetail>;
    totalPrice: number;
    priceAfterDiscount: number;
    saving: number;
}

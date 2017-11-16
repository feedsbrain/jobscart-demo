import { Product } from './product';
import { Customer } from './customer';
import { OrderDetail } from './orderdetail';

export class Order {
    public Id: string;
    public Customer: Customer;
    public OrderDetails: Array<OrderDetail>;
    public TotalPrice: number;
    public PriceAfterDiscount: number;
    public Saving: number;
}

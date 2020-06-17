import { OrderItem } from "./orderItem";

export class Order  {
  public id: number;
  public date: Date;
  public userId: number;
  public datePrevDelivery: Date;
  public cep: string;
  public state: string;
  public city: string;
  public addres: string;
  public addresNumber: string;
  public paymentFormId: number;
  public ordemItems: OrderItem[];
  constructor() {
    this.date = new Date();
    this.ordemItems = [];
  }
}

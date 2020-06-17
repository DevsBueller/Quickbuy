import { Product } from "../../model/product";

export class StoreShoppingCart {
  public products: Product[] = [];

  public add(product: Product) {
    var productLocalStorage = localStorage.getItem("productLocalStorage");
    if (!productLocalStorage) {
      // se não existir produto dentro do localStorage
      this.products.push(product);
    } else {
      // se já existir pelo menos um produto dentro do localstorage
      this.products = JSON.parse(productLocalStorage);
      this.products.push(product);

      }
    localStorage.setItem("productLocalStorage", JSON.stringify(this.products));
  }
  public getProducts(): Product[] {
    var productLocalStorage = localStorage.getItem("productLocalStorage");
    if (productLocalStorage) {
      return JSON.parse(productLocalStorage);
    }
    return this.products;
  }
  public removeProduct(product: Product) {
    var productLocalStorage = localStorage.getItem("productLocalStorage");
    if (productLocalStorage) {
      this.products = JSON.parse(productLocalStorage);
      this.products = this.products.filter(p => p.id != product.id);
      localStorage.setItem("productLocalStorage", JSON.stringify(this.products));
    }
  }
  public update(products: Product[]) {
    localStorage.setItem("productLocalStorage", JSON.stringify(products));
  }
  public existItensShoppingCart(): boolean {
    var itens = this.getProducts();
    return (itens.length > 0);
  }
  public cleanShoppingCart() {
    localStorage.setItem("productLocalStorage", "");
  }
}

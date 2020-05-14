import { Component } from "@angular/core"
@Component({
  selector: "app-produto",
  template: "<html><body>{{GetName()}}</body></html>"
})
export class ProductComponent {// Nome das classes começando com maiúsculo por conta da convenção PascalCase
  /* cameCase par variáveis, atributos, nome de funções */
  public name: string;
  public releasedForSale: boolean;

  public GetName(): string {
    return this.name = "Produto 1";
  }
}

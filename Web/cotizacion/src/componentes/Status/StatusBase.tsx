import { Label } from "@fluentui/react-components";
import React, { useEffect, useState } from "react";
import {
  ArrowDown16Filled,
  ArrowDown24Filled,
  ArrowDown32Filled,
  ArrowUp16Filled,
  ArrowUp24Filled,
  ArrowUp32Filled,
  Circle16Filled,
  Circle20Filled,
} from "@fluentui/react-icons";

interface IAlertBase {
  estado?: string;
}

export const StatusBase = (props: IAlertBase) => {
  const [color, setColor] = useState("");
  const [textColor, setTextColor] = useState("");
  useEffect(() => {
    switch (props.estado) {
      case Estados.APROBADO:
        setColor("#31752f");
        setTextColor("white");

        break;
      case Estados.ENTREGADO:
        setColor("#2b579a");
        setTextColor("white");
        break;
      case Estados.FACTURADO:
        setColor("#004e8c");
        setTextColor("white");
        break;
      case Estados.PAGADO:
        setColor("#F78F1E");
        setTextColor("white");
        break;
      case Estados.PENDIENTE:
        setColor("#e2943a");
        setTextColor("#E49E43");
        break;

      case Estados.REGISTRADO:
        setColor("#00aae4");
        setTextColor("white");
        break;
      case Estados.REVISION:
        setColor("#a4373a");
        setTextColor("white");
        break;
      case Estados.VENTA:
        setColor("#F78F1E");
       
        setTextColor("white");
        break;
        case Estados.DEVOLUCION:
          setColor("#ff6600");
         
          setTextColor("white");
          break;
      case Estados.COMPRA:
        setColor("#39B54A");
        setTextColor("white");
        break;
      default:
        break;
    }
  }, [props.estado]);
  return (
    <>
      <div
        style={{
          display: "flex",
          alignItems: "center",
          justifyContent: "left",
          //backgroundColor: color,

          color: "black",
          borderRadius: 10,
        }}
      >
        {props.estado === Estados.COMPRA ||
        props.estado === Estados.VENTA ||
        props.estado === Estados.DEVOLUCION ? (
          <>
            {props.estado === Estados.COMPRA ? (
              <>
                <div style={{ height: "1rem", width: "1rem" }}>
                  <ArrowUp16Filled style={{ color: color }} />
                </div>
                <br></br>
                <Label
                  weight="semibold"
                  style={{ fontSize: 12, marginLeft: "4px" }}
                >
                  {props.estado}
                </Label>
              </>
            ) : (
              <>
                {" "}
                <div style={{ height: "1rem", width: "1rem" }}>
                  <ArrowDown16Filled style={{ color: color }} />
                </div>
                <br></br>
                <Label
                  weight="semibold"
                  style={{ fontSize: 12, marginLeft: "4px" }}
                >
                  {props.estado}
                </Label>
              </>
            )}
          </>
        ) : (
          <>
            <div style={{ height: "1rem", width: "1rem" }}>
              <Circle16Filled style={{ color: color}} />
            </div>
            <Label
              weight="semibold"
              style={{ fontSize: 12, marginLeft: "4px" }}
            >
              {props.estado}
            </Label>
          </>
        )}
      </div>
    </>
  );
};

export const Estados = {
  REVISION: "Revisión",
  ENTREGADO: "Entregado",
  APROBADO: "Aprobado",
  PENDIENTE: "Pendiente Aprobación" || "Pendiente Aprobacion",
  REGISTRADO: "Registrado",
  FACTURADO: "Facturado",
  PAGADO: "Pagado",
  COMPRA: "Compra",
  VENTA: "Venta",
  DEVOLUCION: "Devolucion" || "Devolución",
};

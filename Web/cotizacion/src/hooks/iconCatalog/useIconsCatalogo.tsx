import { IICON } from "../../interfaces/IICon/IIcon";
import {
  DeleteRegular,
  AddRegular,
  ArrowClockwiseRegular,
  FilterRegular,
  ArrowExitRegular,
  AppsListFilled,
  ArrowDownloadRegular,
  FilterDismissRegular,
  ClockRegular,
  GridDots24Filled,
  AlertRegular,
  SettingsRegular,
  PeopleAudienceRegular,
  CalendarClockRegular,
  PhoneRegular,
  SendRegular,
  ArrowShuffleRegular,
  SignOutRegular,
  DismissRegular
} from "@fluentui/react-icons";

export const useIconsCatalogo = (size: number) => {


  const iconos: IICON[] = [
    {
      key: 'Eliminar',
      text: "Eliminar",
      icon: <DeleteRegular fontSize={size} />,
    },
    {
      key: "Menu",
      text: "Menu",
      icon: <GridDots24Filled fontSize={size} />,
    },
    {
      key: "AddRegular",
      text: "Agregar",
      icon: <AddRegular fontSize={size} />,
    },
    {
      key: "ArrowClockwiseRegular",
      text: "Refrescar",
      icon: <ArrowClockwiseRegular fontSize={size} />,
    },
    {
      key: "FilterRegular",
      text: "Filtro",
      icon: <FilterRegular fontSize={size} />,
    },
    {
      key: "ArrowExitRegular",
      text: "SalirLogin",
      icon: <ArrowExitRegular fontSize={size} />,
    },
    {
      key: "AppsListFilled",
      text: "Detalle",
      icon: <AppsListFilled fontSize={size} />,
    },
    {
      key: "ArrowDownloadRegular",
      text: "Descargar",
      icon: <ArrowDownloadRegular fontSize={size} />,
    },
    {
      key: "FilterDismissRegular",
      text: "LimpiarFiltro",
      icon: <FilterDismissRegular fontSize={size} />,
    },
    {
      key: "SendRegular",
      text: "Enviar",
      icon: <SendRegular fontSize={size} />,
    },
    {
      key: "ReFilterDismissRegularfrescar",
      text: "Reportes",
      icon: <FilterDismissRegular fontSize={size} />,
    },
    {
      key: "ClockRegular",
      text: "Reloj",
      icon: <ClockRegular fontSize={size} />,
    },
    {
      key: "AlertRegular",
      text: "Alerta",
      icon: <AlertRegular fontSize={size} />,
    },
    {
      key: "SettingsRegular",
      text: "Configuraciones",
      icon: <SettingsRegular fontSize={size} />,
    },
    {
      key: "PeopleAudienceRegular",
      text: "ReminderPerson",
      icon: <PeopleAudienceRegular fontSize={size} />
    },
    {
      key: "Refrescar",
      text: "DateTime",
      icon: <CalendarClockRegular fontSize={size} />
    },
    {
      key: "Refrescar",
      text: "BarChartVerticalFill",
      icon: <PeopleAudienceRegular fontSize={size} />
    },
    {
      key: "Celular",
      text: "Celular",
      icon: <PhoneRegular fontSize={size} />
    },
    {
      key: "distribuir",
      text: "Distribuir",
      icon: <ArrowShuffleRegular fontSize={size} />
    },
    {
      key: "SignOutRegular",
      text: "Deslogeo",
      icon: <SignOutRegular fontSize={size} />
    }, {
      key: "DismissRegular",
      text: 'Cancelar',
      icon: <DismissRegular fontSize={size} />
    }


  ];
  type ValoresUnion =
    | "Eliminar"
    | "Enviar"
    | "Menu"
    | "Agregar"
    | "Refrescar"
    | "Filtro"
    | "SalirLogin"
    | "Detalle"
    | "LimpiarFiltro"
    | "Reportes"
    | "Descargar"
    | "FechasIzquierda"
    | "FechasDerecha"
    | "Reloj"
    | "Alerta"
    | "Configuraciones"
    | "ReminderPerson"
    | "DateTime"
    | "Celular"
    | "Distribuir"
    | "Deslogeo"
    | "Cancelar"
    | "BarChartVerticalFill";

  const Icon = (textIcon: ValoresUnion) => {
    const aux = iconos.filter((item) => item.text === textIcon);

    return aux[0]?.icon;
  };

  return { Icon };
};

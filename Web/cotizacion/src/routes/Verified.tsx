import { Outlet } from "react-router-dom";
import { IButtonGroup } from "../interfaces/IButtonsGroup/IButtonGroup";
import { useIconsCatalogo } from "../hooks/iconCatalog/useIconsCatalogo";
import "../App.css";
import "../routes/VerifiedStyle.css";
import { SiderBar } from "../components/siderBar/SiderBar";
import { TreeMenu } from "../interfaces/ISiderBar/ISiderBar";
import { NavBar } from "../components/navBar/NavBar";
export const Verified = () => {


  const linkGroups: TreeMenu[] = [
    {
      key:"Cotizacion",
      name: "Cotizaciones",
      links: [
        {
          key: "1",
          name: "Listado",
          url: "listado",
          icon: "DocumentOnePageAdd20Regular",
        }
      ],
    },
  ];

  const { Icon } = useIconsCatalogo(100);

  const _leftButton: IButtonGroup[] = [
    {
      text: "Actualizar",
      icon: Icon("Menu"),
      //  onClick: postListarTablaControlAcceso,
    },
  ];
  const _rightButton: IButtonGroup[] = [
    {
      text: "Limpiar Filtro",
      icon: Icon("Configuraciones"),
      // onClick: limpiarFiltro,
    },
    {
      text: "Filtrar",
      icon: Icon("Alerta"),
      //  onClick: openPanelAdd,
    },
  ];
  return (
    <>
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          width: "100vw",
          height: "100vh",
        }}
      >
        <NavBar leftButtons={_leftButton} rightButton={_rightButton} />
        <div className="body-core">
          <SiderBar width={350} isOpen={true} linkNavGroups={linkGroups} />
          <div className="outlet-container">
            <Outlet />
          </div>
        </div>
      </div>
    </>
  );
};

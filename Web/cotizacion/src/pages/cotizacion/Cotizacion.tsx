import { TableComponent } from '../../components/tablas/TableComponent'
import { IColumn } from '../../interfaces/ITableComponent/ITableComponent';
import { IButtonGroup } from '../../interfaces/IButtonsGroup/IButtonGroup';
import { useIconsCatalogo } from '../../hooks/iconCatalog/useIconsCatalogo';
import { CabeceraComponent } from '../../components/tablas/cabeceras/CabeceraComponent';

const Cotizacion = () => {
    const { Icon } = useIconsCatalogo(100)
    const _column: IColumn[] = [
        {
            key: 1,
            name: "Fabricante",
            minWidth: 200,
            maxWidth: 200,
            fieldName: "fabricante",
        },
        {
            key: 2,
            name: "Modelo",
            minWidth: 200,
            maxWidth: 200,
            fieldName: "modelo",
        },
        {
            key: 3,
            name: "Código",
            minWidth: 200,
            maxWidth: 200,
            fieldName: "codigo",
        },
        {
            key: 4,
            name: "Serie",
            minWidth: 200,
            maxWidth: 200,
            fieldName: "serie",
        },
        {
            key: 5,
            name: "Punto Control",
            minWidth: 200,
            maxWidth: 200,
            fieldName: "puntoControl",
        },
        {
            key: 6,
            name: "Ubicacion",
            minWidth: 100,
            fieldName: "ubicacion",
        },
    ];
    const _leftButton: IButtonGroup[] = [
        {
            text: "Agregar",
            icon: Icon("Agregar"),
            //onClick: openPanel,
        },
        {
            text: "Actualizar",
            icon: Icon("Refrescar"),
            //onClick: getlistarDispositivos,
        },

    ];

    return (
        <div>
            <CabeceraComponent titulo='Cotizaciones' subTitulo='Esta son las Cotizaciones En General' />
            <TableComponent isSearch={true} column={_column} data={[]} isLoading={false} leftButtons={_leftButton} />
        </div>
    )
}

export default Cotizacion
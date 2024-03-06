import { Button, Persona, Text, makeStyles } from "@fluentui/react-components";
import "../../styles/NavBarV9Style.css"
import { IButtonGroup } from "../../interfaces/IButtonsGroup/IButtonGroup";

const useStyles = makeStyles({
  booton: {
    height: "48px",
    minWidth: "48px",
    ":hover": {
      backgroundColor: "#ECECEC",
      color: "#1267b4",
    },
  },
});
interface INavBarV9 {
  leftButtons: IButtonGroup[];
  rightButton?: IButtonGroup[];
}
export const NavBar = (props: INavBarV9) => {
  const style = useStyles();

  return (
    <>
      <div className="nav">
        <div className="nav-leftItems">
          {props.leftButtons.map((button, index) => (
            <Button
              key={index}
              onClick={button.onClick}
              appearance={button.type == undefined ? "primary" : button.type}
              size="large"
              className={style.booton}
              icon={button.icon}
            />
          ))}
          <div className="contendor">
            <Text className="contendor-texto" weight="regular" size={400}>
              Cotizaciones
            </Text>
          </div>
        </div>
        <div className="nav-rightItems">
          {props.rightButton?.map((button, index) => (
            <Button
              key={index}
              onClick={button.onClick}
              appearance={button.type == undefined ? "primary" : button.type}
              size="large"
              className={style.booton}
              icon={button.icon}
            />
          ))}
          <Button
            className={style.booton}
            appearance="primary"
            onClick={() => {
              // openLogout();
            }}
            icon={
              <div style={{ display: "flex", justifyContent: "center" }}>
                <Persona
                  presence={{ status: "available" }}
                  avatar={{
                    image: {
                      src: "https://res-1.cdn.office.net/files/fabric-cdn-prod_20230815.002/office-ui-fabric-react-assets/persona-male.png",
                    },
                  }}
                />
              </div>
            }
          />
          {/*   <Logout isOpen={isOpen} onDismiss={dismissLogout} customSize={400} /> */}
        </div>
      </div>
    </>
  );
};

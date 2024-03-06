import { Slot } from "@fluentui/react-components";

export interface IICON {
  key: string;
  text: string;
  icon?: Slot<"span">;
}

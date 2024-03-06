import logo from './logo.svg';
import './App.css';
import {
  createDOMRenderer,
  RendererProvider,
} from "@fluentui/react-components";
function App() {
  const renderer = React.useMemo(
    () =>
      createDOMRenderer(document, {
        styleElementAttributes: { nonce: "random" },
      }),
    []
  );
  return (
    <RendererProvider renderer={renderer}>
      <AuthProvider>
        <ContentRouter />
      </AuthProvider>
    </RendererProvider>
  );
}

export default App;

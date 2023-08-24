import "./App.css";
import useTranslatorsQuery from "./hooks/useTranslatorsQuery";
import TranslatorsTable from "./components/TranslatorsTable";
import { useRef, useState } from "react";
import CreateTranslator from "./components/CreateTranslator";

function App() {
  const [searched, setSearched] = useState<string | undefined>(undefined);
  const { data, isLoading } = useTranslatorsQuery(searched);
  const inputRef = useRef<HTMLInputElement | null>(null);
  return (
    <>
      <CreateTranslator />
      <hr />
      <h3>Translators</h3>
      <div>
        <input ref={inputRef} />
        <div style={{ marginTop: "8px" }}>
          <button onClick={_ => setSearched(inputRef.current?.value)}>Search</button>
        </div>
      </div>
      <div>
        <TranslatorsTable data={data} loading={isLoading} />
      </div>
    </>
  );
}

export default App;

import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";
import useTranslatorsQuery from "./hooks/useTranslatorsQuery";
import TranslatorsTable from "./components/TranslatorsTable";

function App() {
  const { data, isLoading } = useTranslatorsQuery();
  return (
    <>
      <input />
      <button>Search</button>

      <TranslatorsTable data={} />
    </>
  );
}

export default App;

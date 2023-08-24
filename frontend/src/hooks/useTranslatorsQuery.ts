import { useQuery } from "react-query";
import { TranslatorsClient } from "../types.generated";

const useTranslatorsQuery = (name?: string) =>
  useQuery(
    ["Translators", name],
    async _ => await new TranslatorsClient("http://localhost:5000").translatorsAll(name),
    {
      staleTime: 1 * 60 * 1000,
    }
  );
export default useTranslatorsQuery;

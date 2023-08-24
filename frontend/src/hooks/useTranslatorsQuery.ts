import { useQuery } from "react-query";
import { TranslatorsClient } from "../types.generated";

const useTranslatorsQuery = (name?: string) => {
  return useQuery(
    ["Translators", name],
    async (_) => await new TranslatorsClient().translatorsAll(name),
    {
      staleTime: 1 * 60 * 1000,
    }
  );
};

export default useTranslatorsQuery;

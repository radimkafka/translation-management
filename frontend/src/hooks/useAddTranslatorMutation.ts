import { useMutation, useQueryClient } from "react-query";
import { AddTranslatorModel, TranslatorsClient } from "../types.generated";

const useAddTranslatorMutation = () => {
  const client = useQueryClient();
  return useMutation(
    async (data: AddTranslatorModel) => await new TranslatorsClient("http://localhost:5000").translators(data),
    {
      onSuccess: () => {
        client.refetchQueries(["Translators"]);
      },
    }
  );
};

export default useAddTranslatorMutation;

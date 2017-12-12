using UDM.Common;

public delegate void DelegateIterationContactCoils(object cObject, object cObjectParent);

static public class CLadderHelper
{
    static public void IterateContactAndCoils(CStep cStep, object cObjectParent, object cObject, DelegateIterationContactCoils delegateContactIteration)
    {
        // Do the delegate first
        delegateContactIteration(cObject, cObjectParent);

        // Iterate Relation
        if (cObject is CCoil || cObject is CContact)
        {
            CRelation relation = cObject is CCoil ? (cObject as CCoil).Relation : (cObject as CContact).Relation;

            // Contact
            for (int i = 0; i < relation.NextContactS.Count; i++ )
            {
                IterateContactAndCoils(cStep, cObject, GetContact(cStep, relation.NextContactS[i]), delegateContactIteration);
            }

            // Coils
            for (int j = 0; j < relation.NextCoilS.Count; j++)
            {
                IterateContactAndCoils(cStep, cObject, GetCoil(cStep, relation.NextCoilS[j]), delegateContactIteration);
            }
        }
    }

    static private CContact GetContact(CStep cStep, int StepIndex)
    {
        CContact cContact = null;

        foreach (CContact cTemp in cStep.ContactS)
        {
            if (cTemp.StepIndex == StepIndex)
            {
                cContact = cTemp;
                break;
            }
        }

        return cContact;
    }

    static private CCoil GetCoil(CStep cStep, int StepIndex)
    {
        CCoil cCoil = null;

        foreach (CCoil cTemp in cStep.CoilS)
        {
            if (cTemp.StepIndex == StepIndex)
            {
                cCoil = cTemp;
                break;
            }
        }

        return cCoil;
    }
}
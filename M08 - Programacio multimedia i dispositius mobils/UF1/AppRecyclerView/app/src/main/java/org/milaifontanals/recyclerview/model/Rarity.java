package org.milaifontanals.recyclerview.model;
import java.util.Arrays;
import java.util.List;

/**
 *
 * @author Jo
 */
public enum Rarity {
    COMMON,
    RARE,
    EPIC;    
    public static List<Rarity> getLlista(){
        return Arrays.asList(Rarity.values());
    }
}

//
//  GroupBuilder.m
//  Anne&DocTique
//
//  Created by Kapi on 01/03/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import "GroupBuilder.h"
#import "Group.h"

@implementation GroupBuilder
//Json Parser
+ (NSArray *)groupsFromJSON:(NSData *)objectNotation error:(NSError **)error
{
    NSLog(@"Parsing is beginning!");
    //Error varible's declaration
    NSError *localError = nil;
    //Dictionary's declaration
    NSDictionary *parsedObject = [NSJSONSerialization JSONObjectWithData:objectNotation options:0 error:&localError];
    //Test
    if (localError != nil) {
        *error = localError;
        return nil;
    }
    //Groups Declaration
    NSMutableArray *groups = [[NSMutableArray alloc] init];
    
    //Debug
    //NSArray *results = [parsedObject valueForKey:@","];
    //NSLog(@"Count %d", results.count);
    
    //Dictionary's elements distribution
    for (NSDictionary *groupDic in parsedObject) {
        Group *group = [[Group alloc] init];
        
        if([groupDic[@"Type"] isEqual:@"VDM"]){
            group.Author = groupDic[@"Author"];
            group.Text = groupDic[@"Text"];
            group.Nbcomments = groupDic[@"NbComments"];
            group.Date= groupDic[@"Date"];
            group.VoteMoins = groupDic[@"Deserved"];
            group.VotePlus = groupDic[@"Agree"];
            group.Id = groupDic[@"Id"];
            group.Type = groupDic[@"Type"];
        }
        else if([groupDic[@"Type"] isEqual:@"DTC"]){
            group.Author = @"";//ya pas
            group.Text = groupDic[@"Text"];
            group.Nbcomments = groupDic[@"NbComments"];
            group.Date= groupDic[@"Date"];//ya pas
            group.VoteMoins = groupDic[@"Bad"];
            group.VotePlus = groupDic[@"Good"];
            group.Id = groupDic[@"Id"];
            group.Type = groupDic[@"Type"];
        }
        else if([groupDic[@"Type"] isEqual:@"CNF"]){
            group.Author = @"";//ya pas
            group.Text = groupDic[@"Texte"];
            group.Nbcomments = groupDic[@"NbComments"];
            group.Date= groupDic[@"Date"];
            group.VoteMoins = groupDic[@"Vote"];
            group.Point = groupDic[@"Points"];
            group.Id = groupDic[@"Id"];
            group.Type = groupDic[@"Type"];
        }
        //To add element to Groups
        [groups addObject:group];
    }
    NSLog(@"Parsing is done!");
    
    return groups;
}
@end

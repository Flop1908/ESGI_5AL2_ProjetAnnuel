//
//  AnneCommunicator.m
//  Anne&DocTique
//
//  Created by Kapi on 01/03/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import "AnneCommunicator.h"
#import "AnneCommunicatorDelegate.h"

NSString *pageCount = @"1";
NSString *pageType = @"Top";
NSString *pageSource = @"VDM_RetreiveAnecdote/";

@implementation AnneCommunicator

- (void)searchCountryAtCoordinate//(CLLocationCoordinate2D)coordinate
{
    //NSString *json=[[NSString alloc] whatSource:*pageSource withType: *pageType andCount:*pageCount];
    NSString *urlAsString = [NSString stringWithFormat:@"http:ralf-esgi.com/app6/servicehello.svc/VDM_RetreiveAnecdote/Last/1"];//@"
    NSURL *url = [[NSURL alloc] initWithString:urlAsString];
    NSLog(@"%@", urlAsString);
    //[NSURLConnection sendSynchronousRequest:[[NSURLRequest alloc] initWithURL:url] returningResponse:[NSURLResponse *response] error:[NSError *error]]
    [NSURLConnection sendAsynchronousRequest:[[NSURLRequest alloc] initWithURL:url] queue:[[NSOperationQueue alloc] init] completionHandler:^(NSURLResponse *response, NSData *data, NSError *error)
    {
        
        if (error) {
            [self.delegate fetchingCountryFailedWithError:error];
        } else {
            [self.delegate receivedGroupsJSON:data];
        }
    }];
}
-(NSString*)WhatSource:(NSString*)source withType:(NSString*)type andCount:(NSString*)count;{
    NSString *jsonURL=[NSString stringWithFormat:@"http:ralf-esgi.com/app6/servicehello.svc/%@_RetreiveAnecdote/%@/%@",source,type,count];
    return jsonURL;
}


@end
